using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonref : MonoBehaviour
{

    worldmove button;
    getonbus button2;
    BusStop2 stop2;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.FindGameObjectWithTag("World").GetComponent<worldmove>();
        button2 = GameObject.FindGameObjectWithTag("BusStop").GetComponent<getonbus>();
        stop2 = GameObject.FindGameObjectWithTag("BusStop").GetComponent<BusStop2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoLeft()
    {
        button.Left();
    }
    public void GoRight()
    {
        button.Right();
    }

    public void Close()
    {
        button.CloseDoor();
    }
    public void Open()
    {
        button2.GetOn();
        stop2.GetOn();
    }

  

}
