using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonref : MonoBehaviour
{

    public worldmove button;
    public worldmove3 button3;
    public getonbus button2;
    public busStop2 stop2;
    public busStop3 stop3;
    public busStop4 stop4;
    public tjunction2 turn;
    // Start is called before the first frame update
    void Start()
    {
        //button = GameObject.FindGameObjectWithTag("World").GetComponent<worldmove>();
        //button2 = GameObject.FindGameObjectWithTag("BusStop").GetComponent<getonbus>();

        //stop2 = GameObject.FindGameObjectWithTag("BusStop2").GetComponent<BusStop2>();
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void GoLeft()
    {
        if (turn.canlanechange == true)
        {
            button.Left();
        }
        if (turn.canlanechange2 == true)
        {
            button3.Left();
        }

    }

    public void GoLeft2()
    {
        
    }

    public void GoRight()
    {
        if (turn.canlanechange == true)
        {
            button.Right();
        }
        if (turn.canlanechange2 == true)
        {
            button3.Right();
        }
    }

    public void GoRight2()
    {
        
    }

    public void Close()
    {
        button.CloseDoor();
        button3.CloseDoor();
    }
    public void Open()
    {
        button2.GetOn();
        stop2.GetOn();
        stop3.GetOn();
        stop4.GetOn();
    }

  

}
