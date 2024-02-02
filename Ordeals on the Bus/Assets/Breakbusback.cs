using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakbusback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Break"))
        {
            Debug.Log("works");
            Destroy(other.gameObject);
        }
    }
}

