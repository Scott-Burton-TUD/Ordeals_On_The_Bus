using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class nomovementSlider : MonoBehaviour
{

    public XRSlider slider;
    public float defaultspeed = 0.3f;
    public float transitionspeed = 1f;
    public bool canSlider;

    public Collider siliderbox;

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
    }

    public void OnTriggerEnter(Collider other)
    {
        canSlider = true;
    }

    public void OnTriggerExit(Collider other)
    {
        canSlider = false;
        siliderbox.enabled = true;
    }
}
