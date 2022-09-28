using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _horizontal, speed = 14;
    [SerializeField] Rigidbody2D body;
    Animator animator;
    Vector3 currentScale;
    bool facingRight = true, ismoving = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        if (body.velocity.x != 0 && body.velocity.y == 0)
        {
            ismoving = true;
        }
        if (body.velocity.x == 0 && body.velocity.y == 0)
        {
            ismoving = false;
        }
        if (ismoving)
        {
            animator.SetFloat("Blend", 0);
        }
        if (!ismoving)
        {
            animator.SetFloat("Blend", 1);
        }
        if(body.velocity.y != 0)
        {
            animator.SetFloat("Blend", 2);
        }
        body.velocity = new Vector2(_horizontal * speed, body.velocity.y);
        currentScale = this.gameObject.transform.localScale;

        if(facingRight &&  body.velocity.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            facingRight = false;
        }

        else if (!facingRight && body.velocity.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            facingRight = true;
        }
    }
}
