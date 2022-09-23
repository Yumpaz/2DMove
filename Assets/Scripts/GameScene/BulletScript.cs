using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos, direction, rotation;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force = 10, rot;
    public static BulletScript Instance;
    public string BulletType;

    private void Awake()
    {
        Instance = this;
    }

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

    public string GetBulletType()
    {
        return BulletType;
    }
}
