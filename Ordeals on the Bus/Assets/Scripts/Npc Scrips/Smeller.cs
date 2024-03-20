using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smeller : MonoBehaviour
{
    public GameObject particleSystemObject;
    private ParticleSystem particleSystemComponent;
    public bool enableParticles;
    private Renderer objectRenderer;
    bool clean = false;

    void Start()
    {
        // Get the ParticleSystem component from the GameObject
        particleSystemComponent = particleSystemObject.GetComponent<ParticleSystem>();
        // Get the renderer component of the object
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Check if the boolean variable is true
        if (enableParticles)
        {
            // Enable the particle system
            particleSystemComponent.Play();
        }
        else
        {
            // Disable the particle system
            particleSystemComponent.Stop();
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Washer"))
        {
            enableParticles = false;
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (other.CompareTag("Bullet"))
        {
            // Change the color of the object to yellow
            objectRenderer.material.color = Color.yellow;
            enableParticles = false;
            clean = true;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}