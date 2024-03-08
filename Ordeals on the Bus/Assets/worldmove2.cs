using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldmove2 : MonoBehaviour
{
    // Variables for world movement
    public float speed = 1;
    public bool candrive;
    public bool canspeed;

    // Variables for parking
    public float targetXPosition = 114.32f; // Change back to X position
    public float moveSpeed = 1f;
    public bool canPark;
    public dockcheck dockk;

    // Reference to stopbus script
    stopbus stoppingbus;

    // Variables for going forward
    public float gobackPosition = 109.42f;

    // Variables for switching lanes
    public GameObject leftButton;
    public GameObject rightButton;
    public float[] lanes;
    private int currentLaneIndex = 1;
    public bool isSwitchingLane = false;

    // Variables for bus leaving
    public npcmovement npcleave;
    public NPC3 npcleave2;
    public NPC4 npcleave3;
    public NPC5 npcleave4;

    public GameObject doorbutton;
    public GameObject busdoor;
    public Animator busdoorAnim;
    public string animationName;

    // Collision with stationary objects
    bool worldStopped = false;
    float originalSpeed;
    float worldStopTimer = 0f;

    void Start()
    {
        stoppingbus = GameObject.FindGameObjectWithTag("Stop").GetComponent<stopbus>();
        busdoorAnim = busdoor.GetComponent<Animator>();
        canspeed = true;
        UpdateBusPosition();
    }

    void Update()
    {
        //bus driving
        drive();

        //Switching lane
        if (!isSwitchingLane)
        {
            // Check for mouse clicks on left and right buttons for lane switching
            if (Input.GetMouseButtonDown(0)) // Left mouse button click
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == leftButton)
                    {
                        SwitchLane(-1); // Move to the left lane
                    }
                    else if (hit.collider.gameObject == rightButton)
                    {
                        SwitchLane(1); // Move to the right lane
                    }
                }
            }
        }

        if (dockk.dockingmode == true && canPark == false)
        {
            buspark(); // Call the BusPark method
        }

        // Check if the world is stopped
        if (worldStopped)
        {
            // Reduce the timer for world stoppage
            worldStopTimer -= Time.deltaTime;

            // Check if the timer has expired
            if (worldStopTimer <= 0f)
            {
                // Resume original speed
                speed = originalSpeed;
                worldStopped = false;
            }
        }
    }

    public void Left()
    {
        if (!isSwitchingLane)
        {
            SwitchLane(-1);
        }
    }

    public void Right()
    {
        if (!isSwitchingLane)
        {
            SwitchLane(1);
        }
    }

    public void CloseDoor()
    {
        if (npcleave.ticket1 == true)
        {
            busdoorAnim.Play(animationName);
            StartCoroutine(MoveOut());
        }

        if (npcleave2.ticket3 == true)
        {
            busdoorAnim.Play(animationName);
            StartCoroutine(MoveOut());
        }

        if (npcleave3.ticket4 == true)
        {
            busdoorAnim.Play(animationName);
            StartCoroutine(MoveOut());
        }

        if (npcleave4.ticket5 == true)
        {
            busdoorAnim.Play(animationName);
            StartCoroutine(MoveOut());
        }
    }

    /// Bus Docking Code
    public void drive()
    {
        if (!worldStopped) // Check if the world is not stopped
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime); // Change back to X axis
        }
    }

    public void buspark()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetXPosition, step), transform.position.y, transform.position.z); // Change back to X axis
        currentLaneIndex = 0;
    }

    void GoBack()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, gobackPosition, step), transform.position.y, transform.position.z); // Change back to X axis
    }

    ///Switching lane Code
    void SwitchLane(int direction)
    {
        currentLaneIndex = Mathf.Clamp(currentLaneIndex + direction, 0, lanes.Length - 1);
        StartCoroutine(MoveToLane(lanes[currentLaneIndex]));
    }

    void UpdateBusPosition()
    {
        StartCoroutine(MoveToLane(lanes[currentLaneIndex]));
    }

    IEnumerator MoveToLane(float targetX)
    {
        isSwitchingLane = true;

        while (Mathf.Abs(transform.position.x - targetX) > 0.01f) // Change back to X axis
        {
            float step = speed * Time.deltaTime;
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetX, step), transform.position.y, transform.position.z); // Change back to X axis
            yield return null;
        }

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z); // Change back to X axis
        isSwitchingLane = false;
    }

    IEnumerator MoveOut()
    {
        yield return new WaitForSeconds(5f);
        canPark = true;
        speed = 1;
        GoBack();

    }

    // Collision with stationary objects
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Traffic"))
        {
            Debug.Log("Collision detected with stationary object");

            // Stop the world for 2 seconds
            originalSpeed = speed;
            speed = 0;
            worldStopped = true;
            worldStopTimer = 2f;

            // Deactivate the stationary object
            other.gameObject.SetActive(false);
        }
    }
}