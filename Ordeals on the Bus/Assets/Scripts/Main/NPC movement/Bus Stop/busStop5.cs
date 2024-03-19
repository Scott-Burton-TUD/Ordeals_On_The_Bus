using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busStop5 : MonoBehaviour
{
    public bool busstoping;
    worldmove4 busstop;

    // Start is called before the first frame update
    void Start()
    {
        busstop = GameObject.FindGameObjectWithTag("World").GetComponent<worldmove4>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            busstoping = true;
            busstop.speed = 0;

        }
    }
}
