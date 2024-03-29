using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float score;
    public float highscore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private Vector3 movement;
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody rb;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();   
        highscoreText = GameObject.Find("Highscore Text").GetComponent<TextMeshProUGUI>();   
    }

    void Start() {
        score = Time.deltaTime;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        score += Time.deltaTime;
        if(score > highscore) {
            highscore = score;
        }
        scoreText.text = "Score: " + Mathf.Floor(score).ToString();
        highscoreText.text = "Highscore: " + Mathf.Floor(highscore).ToString();

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
