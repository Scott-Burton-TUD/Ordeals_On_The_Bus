using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObjects : MonoBehaviour
{
    public NPC6 npc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        npc.run = true;
        npc.movementSpeed = 5f;
    }
}
