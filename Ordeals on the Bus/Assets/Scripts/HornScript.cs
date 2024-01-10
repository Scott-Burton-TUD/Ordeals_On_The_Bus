using UnityEngine;
using UnityEngine.EventSystems;

public class HornScript : MonoBehaviour
{
    public string fmodEvent;

    private void Start()
    {
        // Preload the FMOD event
        FMODUnity.RuntimeManager.LoadBank("SFX", true);
    }

    private void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the FMOD event
            FMODUnity.RuntimeManager.PlayOneShot(fmodEvent, transform.position);
        }
    }
}