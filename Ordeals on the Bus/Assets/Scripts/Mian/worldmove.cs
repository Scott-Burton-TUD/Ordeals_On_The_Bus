using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldmove : MonoBehaviour
{
    public float speed = 1;
    public dockcheck dockk;

    //parking
    public float targetXPosition = 114.32f;
    public float moveSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dockk.dockingmode == false)
        {
            drive();
        }
        else
        {
            buspark();
        }
        
    }

    void drive()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void buspark()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetXPosition, step), transform.position.y, transform.position.z);
    }    
}
