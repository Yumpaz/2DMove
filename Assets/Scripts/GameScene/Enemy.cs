using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health;
    private string BulletType, Status = "rock";

    private void Awake()
    {
        health = 1;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            BulletType = BulletScript.Instance.GetBulletType();
            switch (Status)
            {
                case ("rock"):
                    switch (BulletType)
                    {
                        case ("rock"):

                            break;
                        case ("paper"):
                            Destroy(this.gameObject);
                            break;

                        case ("scissors"):
                            GameManager.Instance.LostHealth();
                            break;
                    }
                    break;
                case ("paper"):
                    switch (BulletType)
                    {
                        case ("rock"):
                            GameManager.Instance.LostHealth();
                            break;
                        case ("paper"):

                            break;

                        case ("scissors"):
                            Destroy(this.gameObject);
                            break;
                    }
                    break;
                case ("scissors"):
                    switch (BulletType)
                    {
                        case ("rock"):
                            Destroy(this.gameObject);
                            break;
                        case ("paper"):
                            GameManager.Instance.LostHealth();
                            break;

                        case ("scissors"):

                            break;
                    }
                    break;
            }
            GameManager.Instance.LostHealth();
        }
    }
}
