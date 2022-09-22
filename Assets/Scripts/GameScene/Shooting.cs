using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos, rotation;
    private float rotZ, timer, timeBetweenFiring = 0.4f;
    public GameObject bullet, brock, bpaper, bscissors;
    public Transform bulletTransform;
    public bool canFire;
    private string bullettype;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        rotation = mousePos - transform.position;

        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetButtonDown("Fire1") && canFire)
        {
            bullettype = GameManager.Instance.GetBulletType();
            canFire = false;
            switch (bullettype)
            {
                case ("rock"):
                    bullet = brock;
                    break;
                case ("paper"):
                    bullet = bpaper;
                    break;
                case ("scissors"):
                    bullet = bscissors;
                    break;
            }
            if (bullettype != "empty")
            {
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            }
        }
    }
}
