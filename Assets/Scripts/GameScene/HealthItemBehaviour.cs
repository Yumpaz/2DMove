using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemBehaviour : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
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
}
