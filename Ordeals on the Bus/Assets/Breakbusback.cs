using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Breakbusback : MonoBehaviour
{
    public GameObject Sceneloader;
    public bool MonkeyCatch = false;
    private bool Eat = false;
    private Vector3 originalPosition = new Vector3(102.6279f, -1.623596f, -154.0749f);
    private float moveSpeed = 1099f;
    private Rigidbody rb;
    private float resetter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found. Attach a Rigidbody to the monkey GameObject.");
        }
    }

    public void EnableEat()
    {
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
            
            if (other.CompareTag("NPC"))
            {
                Debug.Log("hes Eaten");
                Destroy(other.gameObject);

                // Start the coroutine to continuously return to the original position

                Eat = false;
                
            }
        }
    }

   
}