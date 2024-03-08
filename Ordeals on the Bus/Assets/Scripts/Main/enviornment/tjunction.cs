using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tjunction : MonoBehaviour
{
    public Animator tjunctionanimator;
    public GameObject worldmovement;
    public bool candisable;
    public worldmove world1;
    public worldmove2 world2;

    //target location
    public GameObject worldmap;
    public Vector3 targetLocation;
    public Quaternion targetRotation;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

        tjunctionanimator = worldmovement.GetComponent<Animator>();
        StartCoroutine(DisableAnimatorAfterDelay());
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(candisable == true)
        {
            worldmap.transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
            worldmap.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            candisable = true;
            //tjunctionanimator.enabled = true;
            world1.enabled = false;
            //tjunctionanimator.SetBool("left", true);

            

        }
    }

    IEnumerator DisableAnimatorAfterDelay()
    {
        
        yield return new WaitForSeconds(6f);
        if (candisable == true)
        {
            tjunctionanimator.enabled = false;
            world2.enabled = true;
        }


    }
}
