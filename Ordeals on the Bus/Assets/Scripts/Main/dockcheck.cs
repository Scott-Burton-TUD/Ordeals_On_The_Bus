using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dockcheck : MonoBehaviour
{
    public bool dockingmode;
    worldmove busmove;
    worldmove3 busmove3;
    worldmove4 busmove4;

    // Start is called before the first frame update
    void Start()
    {
        busmove = GameObject.FindGameObjectWithTag("World").GetComponent<worldmove>();
        busmove3 = GameObject.FindGameObjectWithTag("World").GetComponent<worldmove3>();
        busmove4 = GameObject.FindGameObjectWithTag("World").GetComponent<worldmove4>();


    }

    // Update is called once per frame
    void Update()
    {
        if(dockingmode == true)
        {
            busmove.buspark();
            busmove3.buspark();
            busmove4.buspark();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dockingmode = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            dockingmode = false;
        }
    }
}
