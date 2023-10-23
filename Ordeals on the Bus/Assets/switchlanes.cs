using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchlanes : MonoBehaviour
{

    public GameObject bus;
    public GameObject[] lanes; // Use GameObjects for lane positions
    public float speed = 5.0f;
    private int currentLane = 1; // Initialize to the middle lane

    private bool isChangingLane = false;

    void Update()
    {
        if (!isChangingLane)
        {
            if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
            {
                SwitchLane(-1); // Move to the left lane
            }
            else if (Input.GetKeyDown(KeyCode.D) && currentLane < lanes.Length - 1)
            {
                SwitchLane(1); // Move to the right lane
            }
        }
    }

    void SwitchLane(int direction)
    {
        int newLane = currentLane + direction;
        if (newLane >= 0 && newLane < lanes.Length)
        {
            currentLane = newLane;
            isChangingLane = true;
            StartCoroutine(MoveBus(lanes[currentLane].transform));
        }
    }

    IEnumerator MoveBus(Transform targetLane)
    {
        Vector3 targetPosition = targetLane.position;

        while (Vector3.Distance(bus.transform.position, targetPosition) > 0.1f)
        {
            targetPosition = targetLane.position; // Update target position to account for moving lanes
            bus.transform.position = Vector3.MoveTowards(bus.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        isChangingLane = false;
    }
}
