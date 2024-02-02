using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakbusback : MonoBehaviour
{
    //public SceneLoader Traffic;
    public GameObject Sceneloader;
    public bool MonkeyCatch = false;
    private bool Eat = false;
    // Start is called before the first frame update
    void Start()
    {
        //if (Traffic != null)
        {
            // Call the method on the referenced script
          //  Traffic.Tracker();
        }
    }
    public void EnableEat()
    {
        Eat = true;
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
    void OnTriggerStay(Collider other)
    {
        if (Eat == true)
        {
            if (other.CompareTag("NPC"))
            {
                Debug.Log("hes Eaten");
                Destroy(other.gameObject);
                Eat = false;
            }
        }
    }
}

