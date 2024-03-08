using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tjunction2 : MonoBehaviour
{
    public Animator tjunctionanimator;
    public GameObject worldmovement;
    public bool candisable2;

    // Start is called before the first frame update
    void Start()
    {
        tjunctionanimator = worldmovement.GetComponent<Animator>();
        if (candisable2 == true)
        {
            StartCoroutine(DisableAnimatorAfterDelay(5f));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tjunctionanimator.SetBool("right", true);
    
        }


    }

    IEnumerator DisableAnimatorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        tjunctionanimator.enabled = false;
    }
}

