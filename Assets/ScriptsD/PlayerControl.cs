using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public static bool MoveLock;

    private void Awake()
    {
        Initial();
    }

    protected virtual void Initial()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (!MoveLock)
            Move();
        else 
        {
            animator.SetBool("Move", false);
            rigidbody2D.velocity = new Vector2(0, 0); 
        }
    }

    protected virtual void Move()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
            animator.SetBool("Move", true);
            if (Input.GetAxis("Horizontal") < 0 && transform.localScale.x > 0 || Input.GetAxis("Horizontal") > 0 && transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            animator.SetBool("Move", false); 
        }
    }
}
