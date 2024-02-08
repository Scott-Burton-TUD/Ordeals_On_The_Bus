using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Breakbusback : MonoBehaviour
{
    public GameObject Sceneloader;
    public bool MonkeyCatch = false;
    private bool Eat = false;
    private Vector3 originalPosition;
    private float moveSpeed = 1099f;
    private Rigidbody rb;
    private float resetter;
    public GameObject NPC1;
    public float eater = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found. Attach a Rigidbody to the monkey GameObject.");
        }
        originalPosition = transform.position;
    }

    public void EnableEat()
    {
        eater += 1;
        Eat = true;
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Break"))
        {
            Debug.Log("works");
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if(Eat == true)
        {
            resetter++;
           
        }
        if (resetter == 2f)
        {
            Eat = false;
            resetter = 0;
        }
        if (Eat == true && rb != null)
        {
            // Move forward using Rigidbody
            rb.MovePosition(rb.position + Vector3.forward * moveSpeed * Time.deltaTime);

            // Log current position for debugging
           // Debug.Log("Current Position: " + transform.position);
            Debug.Log("eat" + Eat);

        }
        if (Eat == false)
        {
            StartCoroutine(ReturnToOriginalPosition());
        }
        Debug.Log("eat" + Eat);
    }
    IEnumerator ReturnToOriginalPosition()
    {
        // Wait for a short delay
        yield return new WaitForSeconds(3f);

        // Log original position for debugging
        Debug.Log("Original Position: " + originalPosition);

        // Continuously move back to the original position
        while (Vector3.Distance(transform.position, originalPosition) > 0.01f)
        {
            rb.MovePosition(Vector3.Lerp(rb.position, originalPosition, moveSpeed * Time.deltaTime));
            yield return null;
        }

        // Reset the Eat flag
        
    }

    void OnTriggerStay(Collider other)
    {
        if (Eat == true)
        {
            
            if (eater == 2)
                {
                    Debug.Log("hes Eaten 1");
                    Destroy(NPC1);
                }
                
                // Start the coroutine to continuously return to the original position

                
            
           
        }
    }

   
}