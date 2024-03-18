using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform Parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Parent != null)
        {
            Vector3 newPosition = Parent.position;
            newPosition.y++; // Increment Y position
            Parent.position = newPosition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Washer"))
        {
            
            Destroy(this.gameObject);
        }
    }
}
