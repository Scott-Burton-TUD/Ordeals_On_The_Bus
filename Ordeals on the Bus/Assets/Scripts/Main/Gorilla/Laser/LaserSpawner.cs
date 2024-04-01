using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    [Header("Laser")]
    public bool CanSpawnLaser;
    public GameObject Laser;
    public float TimerToShoot;
    public GameObject LaserVFX;

    [Header("Cow")]
    public GameObject Cow;
    public GameObject ProjectileLocation;

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
            CanSpawnLaser = true;
            StartCoroutine(SpawnLaser());
        }
    }

    IEnumerator SpawnLaser()
    {
        Laser.SetActive(true);
        yield return new WaitForSeconds(1f);
        LaserVFX.SetActive(true);
        yield return new WaitForSeconds(TimerToShoot);
    }
}
