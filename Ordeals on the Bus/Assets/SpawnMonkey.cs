using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonkey : MonoBehaviour
{
    // Start is called before the first frame update
    public string objectNameToEnable;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monkey"))
        {
            GameObject objectToEnable = GameObject.Find(objectNameToEnable);
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
