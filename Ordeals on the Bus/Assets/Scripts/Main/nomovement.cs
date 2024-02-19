using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nomovement : MonoBehaviour
{
    worldmove busmove;

    // Start is called before the first frame update
    void Start()
    {
        busmove = GameObject.FindGameObjectWithTag("World").GetComponent<worldmove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            busmove.isSwitchingLane = true;
            busmove.canspeed = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            busmove.isSwitchingLane = false;
            busmove.canspeed = true;
        }
    }

}
