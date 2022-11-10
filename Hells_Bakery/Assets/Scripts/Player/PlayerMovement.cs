using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    //public Animator animator;
    Vector3 movement;
    public float score;
    public TextMeshProUGUI scoreText;

    private Vector3 movement;
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody rb;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();     
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        score = score + 1;
        scoreText.text = "Score: " + score.ToString();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.z);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        if (movement.x > 0.1f) {
            sr.flipX = true;
        }
        else if (movement.x < -0.1f) {
            sr.flipX = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
