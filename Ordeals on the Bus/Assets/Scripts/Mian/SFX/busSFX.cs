using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class busSFX : MonoBehaviour
{
    public EventReference bussounds;

    private EventInstance bussoundsfx;


    // Awake is called before Start
    void Awake()
    {
        // Create the EventInstance for bussounds
        
    }

    // Start is called before the first frame update
    void Start()
    {
        bussoundsfx = RuntimeManager.CreateInstance(bussounds);
        bussoundsfx.start();
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any update logic here if needed
    }

    public void SetBusParameter(string parameterName, float parameterValue)
    {
        bussoundsfx.setParameterByName(parameterName, parameterValue);
    }
}