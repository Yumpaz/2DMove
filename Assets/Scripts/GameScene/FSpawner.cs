using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSpawner : MonoBehaviour
{
    public GameObject Floor;
    private void Start()
    {
        Invoke("SpawnFloor", 0);        
    }

    void SpawnFloor()
    {
        Instantiate(Floor, transform.position, Quaternion.identity);
    }
}
