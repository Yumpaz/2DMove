using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D body;
    private TrailRenderer _trailRenderer;
    [SerializeField] private BoxCollider2D coll;
    private bool jumping, _isDashing, _canDash = true;
    private float jforce = 12, fmult = 6.5f, ljmult = 6f, dashingVelocity = 18, dashingtime = 0.2f;
    private Vector2 _dashingDir;
    [SerializeField] private LayerMask jumpableGround;
    private GameObject _currentonewayplatform;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _currentonewayplatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _currentonewayplatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = _currentonewayplatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), platformCollider);
        yield return new WaitForSeconds(0.1f);
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), platformCollider, false);
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

        if (Input.GetButtonDown("Dash") && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            _trailRenderer.emitting = true;
            _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_dashingDir == Vector2.zero)
            {
                _dashingDir = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(StopDashing());
        }

        if (_isDashing)
        {
            body.velocity = _dashingDir.normalized * dashingVelocity;
            return;
        }

        if (IsGrounded())
        {
            _canDash = true;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (_currentonewayplatform != null) { }
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingtime);
        _trailRenderer.emitting = false;
        _isDashing = false;
    }

    private void FixedUpdate()
    {
        if (jumping)
        {
            body.velocity = new Vector2(body.velocity.x, jforce);
            jumping = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}