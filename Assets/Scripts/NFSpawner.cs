using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFSpawner : MonoBehaviour
{
    public GameObject Floor;
    
    private void Start()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("SpawnFloor", 0);
            GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }

    void SpawnFloor()
    {
        Instantiate(Floor, transform.position, Quaternion.identity);
    }
}
