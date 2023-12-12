using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTrigger : MonoBehaviour
{
    public string parameterName;
    public float parameterValue;

    public busSFX busSfxScript; // Reference to the busSFX script

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the busSFX script on the same GameObject
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            busSfxScript.SetBusParameter(parameterName, 0.61f);
        }    
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Change the bus parameter using the reference to busSFX script
            busSfxScript.SetBusParameter(parameterName, parameterValue);
        }
    }
}

