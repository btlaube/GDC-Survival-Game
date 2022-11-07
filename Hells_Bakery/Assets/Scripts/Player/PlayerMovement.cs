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


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        score = score + 1;
        scoreText.text = "Score: " + score.ToString();

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.z);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
