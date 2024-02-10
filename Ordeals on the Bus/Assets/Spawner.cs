using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] gameObjectsToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LOL"))
        {
            foreach (GameObject obj in gameObjectsToActivate)
            {
                obj.SetActive(true);
            }
        }
    }
}