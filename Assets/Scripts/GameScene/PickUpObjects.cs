using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    private string pickupitem;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(WaitToDestroy());
    }

    private void Update()
    {
        rb.velocity = new Vector3(0, -8, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickupitem = this.GetComponent<SpriteRenderer>().sprite.name;
            if (GameManager.Instance.FullInventory() == false)
            {
                GameManager.Instance.AddInventory(pickupitem);
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
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
