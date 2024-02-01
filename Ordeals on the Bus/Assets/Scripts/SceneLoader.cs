using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // The name of the scene to load.


    public void Start()
    {
        GameObject someObject = GameObject.Find("WorldMap");
        if (someObject != null)
        {
            worldmove someScript = someObject.GetComponent<worldmove>();

            if (someScript != null)
            {
                someScript.drive();
            }
        }

        void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Player"))
            {
                float worldmovespeed = other.GetComponent<worldmove>().speed;
                // The object with the "Player" tag has entered the collider.

            }
        }
    }
}