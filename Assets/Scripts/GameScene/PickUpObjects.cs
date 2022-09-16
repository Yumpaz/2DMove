using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    private string pickupitem;

    private void OnTriggerEnter2D(Collider2D collision)
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
}
