using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC4 : MonoBehaviour
{
    [Header("NPC movement speed")]
    public float movementSpeed = 3.0f; // Public variable for controlling the speed
    private NavMeshAgent navMeshAgent;

    [Header("Going to the driver speed")]
    public float dockingspeed = 5f;
    public string targetObjectName; // Change the target variable to string

    [Header("Seats")]
    public bool ticket4;
    public string[] Seats;
    public bool gotoseat;
    private string randomSeatName;

    [Header("Mayham")]
    public bool mayham;
    public string randomMovementAreaName;
    public vipmovement vip;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movementSpeed; // Set the initial speed 


    }

    void Update()
    {
        if (vip.isonFire == true)
        {
            navMeshAgent.isStopped = false;
        }


        if (vip.isonFire == true && !string.IsNullOrEmpty(randomMovementAreaName))
        {
            GameObject randomMovementArea = GameObject.Find(randomMovementAreaName);

            if (randomMovementArea != null)
            {
                // Get the bounds of the BoxCollider
                Vector3 minBounds = randomMovementArea.GetComponent<Collider>().bounds.min;
                Vector3 maxBounds = randomMovementArea.GetComponent<Collider>().bounds.max;

                PerformRandomMovementInArea(minBounds, maxBounds);
            }
            else
            {
                Debug.LogWarning("Random movement area not found.");
            }
        }



        if (vip.isonFire == false && gotoseat == false)
        {
            MoveTowardsTarget(targetObjectName);
        }



        if (ticket4 == true)
        {
            gotoseat = true;
            mayham = false;
        }


        if (gotoseat == true && vip.isonFire == false)
        {
            GoToRandomSeat();
        }
    }


    void GoToRandomSeat()
    {
        if (Seats.Length > 0)
        {
            if (string.IsNullOrEmpty(randomSeatName))
            {
                randomSeatName = Seats[Random.Range(0, Seats.Length)];
            }


            GameObject randomSeat = GameObject.Find(randomSeatName);


            MoveTowardsTarget(randomSeatName); // Pass the string as the target


            if (Vector3.Distance(transform.position, randomSeat.transform.position) < 0.5f)
            {

                transform.eulerAngles = new Vector3(0, 0, 0);


            }
        }
    }



    void MoveTowardsTarget(string targetName)
    {
        if (!string.IsNullOrEmpty(targetName))
        {
            // Find the GameObject with the chosen target name
            GameObject targetObject = GameObject.Find(targetName);

            if (targetObject != null)
            {
                // Use NavMeshAgent for smooth navigation
                navMeshAgent.SetDestination(targetObject.transform.position);
            }
        }
    }



    void PerformRandomMovementInArea(Vector3 minBounds, Vector3 maxBounds)
    {
        // Check if the NavMeshAgent has reached the current destination
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            // Generate a random point within the specified rectangular area
            Vector3 randomDestination = RandomNavInBounds(minBounds, maxBounds);

            // Set the destination for the NavMeshAgent
            navMeshAgent.SetDestination(randomDestination);
        }
    }

    Vector3 RandomNavInBounds(Vector3 minBounds, Vector3 maxBounds)
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y),
            Random.Range(minBounds.z, maxBounds.z)
        );

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, 5f, -1);

        return navHit.position;
    }
}