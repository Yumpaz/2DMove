using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(WaitToDestroy());
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(GameManager.Instance.GetHealth() < 3)
            {
                GameManager.Instance.GainHealth();
                Destroy(this.gameObject);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    public IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }
}
