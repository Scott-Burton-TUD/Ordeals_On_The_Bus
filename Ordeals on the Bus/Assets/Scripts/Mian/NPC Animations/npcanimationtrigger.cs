using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcanimationtrigger : MonoBehaviour
{
    public Animator bananaAnimations;
    public string animationName;
    // Start is called before the first frame update
    void Start()
    {
        bananaAnimations = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            bananaAnimations.Play(animationName);
        }
      
    }
}
