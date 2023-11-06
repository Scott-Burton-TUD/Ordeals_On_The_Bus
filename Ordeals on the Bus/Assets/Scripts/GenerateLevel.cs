using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public float zPos = 26.2f;
    public bool CreatingSection = false;
    public int secNum;
    public GameObject[] x;

    void Update()
    {
        if (CreatingSection == false)
        {
            CreatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {

        secNum = Random.Range(0, 1);
        if (Input.GetKey(KeyCode.Space))
        {
            secNum = 2;
        }
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 26;
        yield return new WaitForSeconds(2);
        CreatingSection = false;
    } 
}