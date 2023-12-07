using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCspawn : MonoBehaviour
{
    public GameObject[] npcPrefabs; // Array of NPC prefabs, assign them in the Unity Editor
    public int numberOfNPCs = 5; // Adjust the number of NPCs you want to instantiate
    public float spaceBetweenNPCs = 2.0f; // Adjust the space between NPCs

    private List<GameObject> spawnedNPCs = new List<GameObject>(); // Keep track of spawned NPCs
    private int currentNPCIndex = 0; // Keep track of the current NPC index

    void Start()
    {
        InstantiateNPCs();
    }

    void Update()
    {
        // Check for the 'L' key press
        if (Input.GetKeyDown(KeyCode.L))
        {
            ActivateNextBoardingScript();
        }
    }

    void InstantiateNPCs()
    {
        for (int i = 0; i < numberOfNPCs; i++)
        {
            // Randomly select an NPC prefab from the array
            GameObject selectedPrefab = npcPrefabs[Random.Range(0, npcPrefabs.Length)];

            // Instantiate the selected NPC with space between them
            GameObject npc = Instantiate(selectedPrefab, transform.position - new Vector3(0, 0, i * spaceBetweenNPCs), Quaternion.identity);

            // Set the instantiated NPC as a child of the parent GameObject
            npc.transform.parent = transform;

            // Add the spawned NPC to the list
            spawnedNPCs.Add(npc);

            // Enable the BoardingBus script only for the first NPC, disable for others
            if (i != 0)
            {
                npc.GetComponent<BoardingBus>().enabled = false;
            }
        }
    }

    void ActivateNextBoardingScript()
    {
        // Check if there are more NPCs to activate
        if (currentNPCIndex < spawnedNPCs.Count)
        {
            // Enable the BoardingBus script for the current NPC
            spawnedNPCs[currentNPCIndex].GetComponent<npcmovement>().enabled = true;
            spawnedNPCs[currentNPCIndex].GetComponent<NavMeshAgent>().enabled = true;


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