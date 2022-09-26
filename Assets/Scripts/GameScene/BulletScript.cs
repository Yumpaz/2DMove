using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos, direction, rotation;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force = 10, rot;
    public string EnemyType, BulletType;
    private Enemy InteractEnemy;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        BulletType = Shooting.Instance.GetBulletType();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - transform.position;
        rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            InteractEnemy = collision.GetComponent<Enemy>();
            EnemyType = InteractEnemy.GetEnemyType();
            switch (BulletType)
            {
                case ("rock"):
                    switch (EnemyType)
                    {
                        case ("rock"):
                            InteractEnemy.ShowStatus();
                            InteractEnemy.HideStatus2();
                            Destroy(this.gameObject);
                            break;
                        case ("paper"):
                            InteractEnemy.ShowStatus();
                            GameManager.Instance.LostHealth();
                            InteractEnemy.HideStatus2();
                            Destroy(this.gameObject);
                            break;
                        case ("scissors"):
                            Destroy(InteractEnemy.gameObject);
                            Destroy(this.gameObject);
                            break;
                    }
                    break;
                case ("paper"):
                    switch (EnemyType)
                    {
                        case ("rock"):
                            Destroy(InteractEnemy.gameObject);
                            Destroy(this.gameObject);
                            break;
                        case ("paper"):
                            InteractEnemy.ShowStatus();
                            InteractEnemy.HideStatus2();
                            Destroy(this.gameObject);
                            break;
                        case ("scissors"):
                            InteractEnemy.ShowStatus();
                            GameManager.Instance.LostHealth();
                            InteractEnemy.HideStatus2();
                            Destroy(this.gameObject);
                            break;
                    }
                    break;
                case ("scissors"):
                    switch (EnemyType)
                    {
                        case ("rock"):
                            InteractEnemy.ShowStatus();
                            GameManager.Instance.LostHealth();
                            InteractEnemy.HideStatus2();
                            Destroy(this.gameObject);
                            break;
                        case ("paper"):
                            Destroy(InteractEnemy.gameObject);
                            Destroy(this.gameObject);
                            break;
                        case ("scissors"):
                            InteractEnemy.ShowStatus();
                            InteractEnemy.HideStatus2();
                            Destroy(this.gameObject);
                            break;
                    }
                    break;
            }
        }
    }
}
