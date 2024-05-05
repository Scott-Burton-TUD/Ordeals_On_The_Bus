using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class ParameterChangeTrigger : MonoBehaviour
{
    [Header("Parameter Change")]
    [SerializeField] private string parameterName;
    [SerializeField] private float parameterValue = 0;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Driver"))
        {
            AudioManager.instance.SetEngineParameter(parameterName, parameterValue);
            Debug.Log(parameterValue);

        }
    }
}
