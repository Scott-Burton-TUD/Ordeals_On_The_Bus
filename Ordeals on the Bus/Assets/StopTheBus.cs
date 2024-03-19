using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class StopTheBus : MonoBehaviour
{

    public XRSlider slider;
    public float defaultspeed = 0.3f;
    public float transitionspeed = 1f;
    public bool canSlider;
    public Breakbusback Eatfnc;
    public Collider siliderbox;
    public Collider Car;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canSlider == true)
        {
            siliderbox.enabled = false;

            if (slider.value != defaultspeed)
            {
                slider.value = Mathf.Lerp(slider.value, defaultspeed, transitionspeed * Time.deltaTime);

            }
        }
        if (Eatfnc != null)
        {
            // Call the method on the referenced script
            Eatfnc.EnableEat();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canSlider = true;
            Eatfnc.EnableEat();
        }
        Car.enabled = false; 
    }
    

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canSlider = false;
            siliderbox.enabled = true;
        }

    }
}
