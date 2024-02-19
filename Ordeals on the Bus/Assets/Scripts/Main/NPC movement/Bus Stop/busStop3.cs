using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class busStop3 : MonoBehaviour
{
    public List<GameObject> npc = new List<GameObject>(); // Keep track of spawned NPCs
    public int currentNPCIndex = 0; // Keep track of the current NPC index

    public GameObject doorbutton;


    public bool canSpawn3;
    public GameObject busdoor;
    public Animator busdoorAnim;
    public string animationName;

    //bool
    public npcspawnbool3 inZone;


    void Start()
    {
        busdoorAnim = busdoor.GetComponent<Animator>();

    }

    void Update()
    {

        


    }

    public void GetOn()
    {
        if (canSpawn3 == true && inZone.businzone3 == true)
        {
            busdoorAnim.Play(animationName);
            StartCoroutine(DoorOpening());
        }
    }


    IEnumerator DoorOpening()
    {
        yield return new WaitForSeconds(2.5f);
        currentNPCIndex = 0;
        npc[currentNPCIndex].GetComponent<NPC4>().enabled = true;
        npc[currentNPCIndex].GetComponent<NavMeshAgent>().enabled = true;

    }
}
