using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private GameObject djplatform;
    [SerializeField] private BoxCollider2D coll;
    private bool jumping;
    private bool grounded;
    private float jforce = 6;
    private float fmult = 2.5f;
    private float ljmult = 2f;
    [SerializeField] private LayerMask jumpableGround;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        djplatform.GetComponent<BoxCollider2D>().enabled = !djplatform.GetComponent<BoxCollider2D>().enabled;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
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
        if (jumping)
        {
            body.velocity = new Vector2(body.velocity.x, jforce);
            GameManager.Instance.increaseScore();
            djplatform.GetComponent<BoxCollider2D>().enabled =  !djplatform.GetComponent<BoxCollider2D>().enabled;
            jumping = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}