using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dockcheck : MonoBehaviour
{
    public bool dockingmode;
    worldmove busmove;


    // Start is called before the first frame update
    void Start()
    {
        busmove = GameObject.FindGameObjectWithTag("World").GetComponent<worldmove>();



    }

    // Update is called once per frame
    void Update()
    {
        if(dockingmode == true)
        {
            busmove.buspark();
 
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
