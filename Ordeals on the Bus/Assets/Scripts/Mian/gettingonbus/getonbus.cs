using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class getonbus : MonoBehaviour
{
    public List<GameObject> npc = new List<GameObject>(); // Keep track of spawned NPCs
    private int currentNPCIndex = 0; // Keep track of the current NPC index

    void Start()
    {
    }

    void Update()
    {
        // Check for the 'L' key press
        if (Input.GetKeyDown(KeyCode.L))
        {
            ActivateNextBoardingScript();
        }
    }

    void ActivateNextBoardingScript()
    {
        // Check if there are more NPCs to activate
        if (currentNPCIndex < npc.Count)
        {
            if (currentNPCIndex == 0 || currentNPCIndex == 1)
            {
                // First and second NPCs are the same
                npc[currentNPCIndex].GetComponent<npcmovement>().enabled = true;
                npc[currentNPCIndex].GetComponent<NavMeshAgent>().enabled = true;
            }
            else if (currentNPCIndex == 2)
            {
                // Third NPC is different
                npc[currentNPCIndex].GetComponent<vipmovement>().enabled = true;
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