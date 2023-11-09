using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab you want to spawn.
    public Transform[] spawnPoints; // Array to hold the spawn points.
    public float moveSpeed = 2f; // Speed at which the spawner moves backward.

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private void Update()
    {
        // Move the spawner backward.
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    IEnumerator SpawnObjects()
    {
        while (true) // Spawning objects continuously.
        {
            // Randomly select a spawn point.
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomSpawnIndex];

            // Instantiate the object at the selected spawn point.
            Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);

            // Wait for some time before spawning the next object.
            yield return new WaitForSeconds(5.0f);
        }
    }
}