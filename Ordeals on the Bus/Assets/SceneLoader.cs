using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // The object with the "Player" tag has entered the collider.
            SceneManager.LoadScene(sceneToLoad); // Load the specified scene.
        }
    }
}