using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODEvent : MonoBehaviour
{
    [field: Header("Music")]

    [field: SerializeField] public EventReference music { get; private set; }

    [field: Header("Engine")]

    [field: SerializeField] public EventReference engine { get; private set; }

   public static FMODEvent instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(">1 Events instances in the scene.");
        }
        instance = this;
    }
}
