using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class getonbus : MonoBehaviour
{
    public List<GameObject> npc = new List<GameObject>(); // Keep track of spawned NPCs
    public int currentNPCIndex = 0; // Keep track of the current NPC index

    public GameObject doorbutton;


    public npcmovement npc1;
    public npcmovement2 npc2;
    public bool canSpawn;


    void Start()
    {

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == doorbutton && canSpawn == true)
                {
                    StartCoroutine(DoorOpening());
                }
            }
        }

        ActivateNPC();


    }

    public void GetOn()
    {
        if (canSpawn == true)
        {
            StartCoroutine(DoorOpening());
        }
    }

    void ActivateNPC()
    {
        if (npc1.ticket1 == true)
        {
            currentNPCIndex = 1;
            npc[currentNPCIndex].GetComponent<npcmovement2>().enabled = true;
            npc[currentNPCIndex].GetComponent<NavMeshAgent>().enabled = true;
        }
        
        if(npc2.ticket2 == true)
        {
            currentNPCIndex = 2;
            npc[currentNPCIndex].GetComponent<npcmovement3>().enabled = true;
            npc[currentNPCIndex].GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    void FristNPC()
    {
        
    }    

    IEnumerator DoorOpening()
    {
        yield return new WaitForSeconds(2.5f);
        currentNPCIndex = 0;
        npc[currentNPCIndex].GetComponent<npcmovement>().enabled = true;
        npc[currentNPCIndex].GetComponent<NavMeshAgent>().enabled = true;

    }







    void ActivateNextBoardingScript()
    {
        // Check if there are more NPCs to activate
        if (currentNPCIndex < npc.Count)
        {
            if (currentNPCIndex == 0)
            {
                // First and second NPCs are the same
                npc[currentNPCIndex].GetComponent<npcmovement>().enabled = true;
                npc[currentNPCIndex].GetComponent<NavMeshAgent>().enabled = true;
            }
            else if (currentNPCIndex == 1)
            {
                // Third NPC is different
                npc[currentNPCIndex].GetComponent<npcmovement2>().enabled = true;
                npc[currentNPCIndex].GetComponent<NavMeshAgent>().enabled = true;
            }
            else if (currentNPCIndex == 2)
            {
                npc[currentNPCIndex].GetComponent<npcmovement3>().enabled = true;
                npc[currentNPCIndex].GetComponent<NavMeshAgent>().enabled = true;
            }

                // Increment the index for the next NPC
                currentNPCIndex++;
        }
        else
        {
            // All NPCs have boarded the bus
            Debug.Log("All NPCs have boarded the bus!");
        }
    }
}
