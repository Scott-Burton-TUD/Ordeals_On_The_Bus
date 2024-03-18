using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopbus2 : MonoBehaviour
{
    public bool busstoping;
    worldmove3 busstop;
    Collider coll;
    public busStop3 npcbus;

    // Start is called before the first frame update
    void Start()
    {
        busstop = GameObject.FindGameObjectWithTag("World").GetComponent<worldmove3>();

        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            busstoping = true;
            busstop.speed = 0;
            coll.enabled = false;
            npcbus.canSpawn3 = true;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            busstoping = false;
        }
    }
}