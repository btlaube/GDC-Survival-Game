using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    //public Animator animator;

    private Vector3 movement;
    private SpriteRenderer sr;
    private Animator animator;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();     
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        if (movement.x > 0.1f) {
            sr.flipX = true;
        }
        else if (movement.x < -0.1f) {
            sr.flipX = false;
        }
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.z);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
