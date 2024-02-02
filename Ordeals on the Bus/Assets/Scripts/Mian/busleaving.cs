using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busleaving : MonoBehaviour
{
    npcmovement3 busleave;
    public bool test;

    // Start is called before the first frame update
    void Start()
    {
        busleave = GameObject.FindGameObjectWithTag("LastNPC").GetComponent<npcmovement3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(test == true)
        {
            busleave.ticke3 = false;
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
