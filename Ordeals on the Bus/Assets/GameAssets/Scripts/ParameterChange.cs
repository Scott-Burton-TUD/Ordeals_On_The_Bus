using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterChange : MonoBehaviour
{


    [Header("Parameter Change")]
    [SerializeField] private string parameterName;
    [SerializeField] private float parameterValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Driver"))
        {
            AudioManager.instance.SetEngineParameter(parameterName, parameterValue);
            parameterValue = 1;
        }
    }
}
