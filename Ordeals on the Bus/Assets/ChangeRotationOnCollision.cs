using UnityEngine;

public class ChangeRotationOnCollision : MonoBehaviour
{
    // Target object whose rotation will change
    public GameObject targetObject;

    // Rotation angle to apply
    public float rotationAngle = -180f;

    // Check for collisions
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged as "Player" and if the target object is assigned
        if (collision.gameObject.CompareTag("Player") && targetObject != null)
        {
            // Change the rotation of the target object on the y-axis by the specified angle
            targetObject.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }
}