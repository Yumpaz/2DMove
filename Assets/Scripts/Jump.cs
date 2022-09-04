using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D body;
    private bool jumping;
    private bool grounded;
    private float jforce = 6;
    private float fmult = 2.5f;
    private float ljmult = 2f;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
        }

        if (body.velocity.y < 0)
        {
            body.gravityScale = fmult;
        }
        else if (body.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            body.gravityScale = ljmult;
        }
        else
        {
            body.gravityScale = 1;
        }
    }

    private void FixedUpdate()
    {
        if (grounded)
        {
            if (jumping)
            {
                body.AddForce(new Vector2(body.velocity.x, jforce), ForceMode2D.Impulse);
                jumping = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = false;
        }
    }
}
