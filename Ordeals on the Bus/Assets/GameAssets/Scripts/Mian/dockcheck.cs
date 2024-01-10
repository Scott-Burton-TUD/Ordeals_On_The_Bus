using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dockcheck : MonoBehaviour
{
    public bool dockingmode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dockingmode = true;
        }
    }
}
