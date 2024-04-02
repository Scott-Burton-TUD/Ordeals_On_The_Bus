using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrossingTrigger : MonoBehaviour
{
    [Header("Lists of Bananas")]
    public List<GameObject> npc = new List<GameObject>();
    public int currentNPCIndex = 0;

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
        if(other.CompareTag("Player"))
        {
            foreach (GameObject obj in npc)
            {
                obj.GetComponent<NavMeshAgent>().enabled = true;
                obj.GetComponent<BananaCrossing>().enabled = true;
            }
        }
    }
}
