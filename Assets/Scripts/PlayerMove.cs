using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private Animator anim;

    [SerializeField] private SpriteRenderer spriteRend;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float speed;

    public TextControl control;

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && control.tap_tr) {
            rb.velocity = new Vector2 (-speed, rb.velocity.y);
            anim.SetInteger("mn",1);
            spriteRend.flipX = true;
        } else if (Input.GetKey(KeyCode.D) && control.tap_tr) {
            rb.velocity = new Vector2 (speed, rb.velocity.y);
            anim.SetInteger("mn",1);
            spriteRend.flipX = false;
        } else {
            rb.velocity = new Vector2 (0, rb.velocity.y);
            anim.SetInteger("mn",0);            
        }

    }
}
