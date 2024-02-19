using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BusStop2 : MonoBehaviour
{
    public List<GameObject> npc = new List<GameObject>(); // Keep track of spawned NPCs
    public int currentNPCIndex = 0; // Keep track of the current NPC index

    public GameObject doorbutton;


    public npcmovement npc1;
    public npcmovement2 npc2;
    public bool canSpawn;
    public GameObject busdoor;
    public Animator busdoorAnim;
    public string animationName;

    //bool
    npcspawnbool inZone;


    void Start()
    {
        busdoorAnim = busdoor.GetComponent<Animator>();
    }

    void Update()
    {      
        ActivateNPC();
    }

    public void GetOn()
    {
        if (canSpawn == true && inZone.businzone1 == true)
        {
            busdoorAnim.Play(animationName);
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

        if (npc2.ticket2 == true)
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
}