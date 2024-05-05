using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangeTrigger : MonoBehaviour
{
    [Header("Area")]
    [SerializeField] private MusicArea area;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Driver"))
        {
            AudioManager.instance.SetMusicArea(area);
        }
    }
}
