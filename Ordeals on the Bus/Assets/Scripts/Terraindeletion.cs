using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terraindeletion : MonoBehaviour
{
    void Update()
    {
        Invoke("destroyer", 20f);
    }
    void destroyer()
    {
        Destroy(gameObject);
    }
}

