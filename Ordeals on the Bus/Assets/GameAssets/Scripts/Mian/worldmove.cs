using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

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
    [SerializeField] private EventReference hornSound;

    public stopbus stoppingbus;

    //going forward
    public float gobackPosition = 109.42f;

    //switching lane
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject hornButton;
    public float[] lanes;
    private int currentLaneIndex = 1;
    private bool isSwitchingLane = false;




    // Start is called before the first frame update
    void Start()
    {
        UpdateBusPosition();
    }

    // Update is called once per frame
    void Update()
    {
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
                    Debug.Log("Hit object: " + hit.collider.gameObject.name);
                    if (hit.collider.gameObject == hornButton)
                    {
                  
                        Debug.Log("obefvb");
                        AudioManager.instance.PlayOneShot(hornSound, this.transform.position);
                        
                    }
                    else if (hit.collider.gameObject == leftButton)
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



            //Bus docking
            if (stoppingbus.busstoping == false)
        {
            drive();
        }

        if (dockk.dockingmode == true && canPark == false)
        {
            buspark();
        }

        if (Input.GetKey(KeyCode.P))
        {
            goback();
            canPark = true;
            stoppingbus.busstoping = false;
        }


    }


    /// Bus Docking Code
    void drive()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void buspark()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetXPosition, step), transform.position.y, transform.position.z);
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
}
