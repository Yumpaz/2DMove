using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFSpawner : MonoBehaviour
{
    public GameObject Floor;
    public GameObject Platform;
    private float x, y, z;
    Vector3 spawnPosition = new Vector3();

    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        if (collision.gameObject.tag == "Player")
        {
            Invoke("SpawnFloor", 0);
            for (int i = 0; i < 10; i++)
            {
                spawnPosition.x = Random.Range(-20f, 20f);
                spawnPosition.y = Random.Range(1f, 8f);
                Instantiate(Platform, transform.position + spawnPosition, Quaternion.identity);
            }
        }
        
        
    }

    void SpawnFloor()
    {
        Instantiate(Floor, transform.position, Quaternion.identity);
    }
}
