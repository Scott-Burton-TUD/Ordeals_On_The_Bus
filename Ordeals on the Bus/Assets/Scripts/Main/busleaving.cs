using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busleaving : MonoBehaviour
{
    NPC3 busleave;
    npcmovement busleave1;
    public bool test;

    // Start is called before the first frame update
    void Start()
    {
        busleave = GameObject.FindGameObjectWithTag("Second NPC").GetComponent<NPC3>();
        busleave1 = GameObject.FindGameObjectWithTag("First NPC").GetComponent<npcmovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(test == true)
        {
            busleave.ticket3 = false;
            busleave1.ticket1 = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            test = true;
        }
    }
}
