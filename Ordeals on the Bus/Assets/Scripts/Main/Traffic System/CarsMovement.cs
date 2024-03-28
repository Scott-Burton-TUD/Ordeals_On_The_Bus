using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMovement : MonoBehaviour
{
    public float speed;
    public bool lane1;
    public bool lane2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lane1 == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            speed = 0;
        }
    }
}
