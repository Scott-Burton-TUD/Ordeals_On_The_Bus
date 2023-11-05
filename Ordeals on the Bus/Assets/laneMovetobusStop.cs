using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laneMovetobusStop : MonoBehaviour
{
    public Transform target; // The target GameObject to move towards
    public Vector3 offset;   // The offset from the target's position
    public float moveSpeed = 5f; // The movement speed
    public float stoppingDistance = 0.1f; // The distance at which movement stops

    private bool isMoving = true;

    private void Update()
    {
        if (isMoving && target != null)
        {
            // Calculate the target position with the offset
            Vector3 targetPosition = target.position + offset;

            // Calculate the direction from the current position to the target position
            Vector3 moveDirection = targetPosition - transform.position;

            // Calculate the distance to the target position
            float distanceToTarget = moveDirection.magnitude;

            // If the distance is greater than the stopping distance, move the GameObject
            if (distanceToTarget > stoppingDistance)
            {
                // Normalize the direction vector
                moveDirection.Normalize();

                // Move the GameObject towards the target
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            }
            else
            {
                // The GameObject has arrived at the target, so stop moving
                isMoving = false;
            }
        }
        else
        {
            Debug.LogWarning("Target GameObject is not set.");
        }
    }
}
