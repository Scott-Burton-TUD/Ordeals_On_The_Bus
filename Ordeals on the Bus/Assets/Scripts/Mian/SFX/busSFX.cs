using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class busSFX : MonoBehaviour
{
    public Transform engine;
    public GameObject busstop;
    public GameObject busstart;

    public soundTrigger dockk;

    //stopping bus
    public stopbus stoppingbus;

    //Fmod

    public EventReference busIdle;
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(busIdle, engine.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(dockk.sfxTrigger == true)
        {
            busstop.SetActive(true);
        }
        else
        {
            busstop.SetActive(false);
        }

        if (Input.GetKey(KeyCode.P))
        {
            busstart.SetActive(true);
        }
    }
}
