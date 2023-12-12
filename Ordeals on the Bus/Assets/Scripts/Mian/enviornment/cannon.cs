using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class cannon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject cannonballPrefab;
    public float launchForce = 10f;
    public EventReference cannonSound;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FireCannon();
        }
    }

    void FireCannon()
    {
        // Instantiate a cannonball at the firePoint position and rotation
        GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the cannonball    
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();

        // Check if the Rigidbody component exists
        if (rb != null)
        {
            // Apply force to the cannonball in the forward direction
            rb.AddForce(firePoint.forward * launchForce, ForceMode.Impulse);

            // Play the FMOD sound event
            FMODUnity.RuntimeManager.PlayOneShot(cannonSound, firePoint.position);
        }
        else
        {
            Debug.LogError("Cannonball prefab is missing Rigidbody component!");
        }
    }
}
