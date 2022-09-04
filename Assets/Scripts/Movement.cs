using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _horizontal;
    private float speed = 5;
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * speed;
    }
}