using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class worldmove : MonoBehaviour
{
    //world move
    public float speed = 1;


    //parking
    public float targetXPosition = 114.32f;
    public float moveSpeed = 1f;
    public bool canPark;
    public dockcheck dockk;

    //stopping bus
    stopbus stoppingbus;

    //going forward
    public float gobackPosition = 109.42f;

    //switching lane
    public GameObject leftButton;
    public GameObject rightButton;
    public float[] lanes;
    private int currentLaneIndex = 1;
    public bool isSwitchingLane = false;

    //bus leaving
    npcmovement3 npcleave;
    public GameObject doorbutton;



    // Start is called before the first frame update
    void Start()
    {
        stoppingbus = GameObject.FindGameObjectWithTag("Stop").GetComponent<stopbus>();
        npcleave = GameObject.FindGameObjectWithTag("LastNPC").GetComponent<npcmovement3>();
        UpdateBusPosition();


    }

    // Update is called once per frame
    void Update()
    {
        //bus driving
        drive();

        //Switching lane
        if (!isSwitchingLane)
        {
            // Check for mouse clicks on objectToClick and objectToClick2
            if (Input.GetMouseButtonDown(0)) // Left mouse button click
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == leftButton)
                    {
                        SwitchLane(-1); // Move to the left lane
                    }
                    else if (hit.collider.gameObject == rightButton)
                    {
                        SwitchLane(1); // Move to the right lane
                    }
                }
            }
        }

        if (dockk.dockingmode == true && canPark == false)
        {
            //buspark();
        }

        //Bus leaving

      


        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == doorbutton)
                {
                    
                    if (npcleave.ticke3 == true)
                    {
                        StartCoroutine(MoveOut());
                    }
                    
                    
                }
            }
        }

        

    }
    public void Left()
    {
        if (!isSwitchingLane)
        {
            SwitchLane(-1);
        }          
    }

    public void Right()
    {
        if (!isSwitchingLane)
        {
            SwitchLane(1);
        }         
    }

    public void CloseDoor()
    {
        if (npcleave.ticke3 == true)
        {
            StartCoroutine(MoveOut());
        }
    }


    /// Bus Docking Code
    public void drive()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void buspark()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetXPosition, step), transform.position.y, transform.position.z);
        currentLaneIndex = 0;
    }

    void goback()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, gobackPosition, step), transform.position.y, transform.position.z);
    }


    ///Switching lane Code
    void SwitchLane(int direction)
    {
        currentLaneIndex = Mathf.Clamp(currentLaneIndex + direction, 0, lanes.Length - 1);
        StartCoroutine(MoveToLane(lanes[currentLaneIndex]));
    }

    void UpdateBusPosition()
    {
        StartCoroutine(MoveToLane(lanes[currentLaneIndex]));
    }

    IEnumerator MoveToLane(float targetX)
    {
        isSwitchingLane = true;

        while (Mathf.Abs(transform.position.x - targetX) > 0.01f)
        {
            float step = speed * Time.deltaTime;
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetX, step), transform.position.y, transform.position.z);
            yield return null;
        }

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        isSwitchingLane = false;
    }

    IEnumerator MoveOut()
    {
        yield return new WaitForSeconds(5f);
        canPark = true;
        speed = 1;
        goback();

    }

}
