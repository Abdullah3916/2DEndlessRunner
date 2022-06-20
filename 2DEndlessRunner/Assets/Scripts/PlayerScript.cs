using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    private float score;
    private float yValue;
    public Animator animator;

    [SerializeField]
    private bool isGrounded;

    private bool isAlive = true;
    private Rigidbody2D RB;

    public Text ScoreTxt;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        JumpAnimation();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (isAlive)
        {
            score += Time.deltaTime * 2;
            ScoreTxt.text = "SCORE; " + score.ToString();
        }
    }

    void JumpAnimation()
    {
        if (isGrounded)
        {
            animator.SetBool("isFalling" ,false);
            animator.SetBool("isJumping" ,false);
        }
        else if (transform.position.y <yValue)
        {
            animator.SetBool("isJumping" ,true);
            animator.SetBool("isFalling" ,false);
        }

        else if (transform.position.y > yValue)
        {
            animator.SetBool("isJumping",false);
            animator.SetBool("isFalling" ,true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            isAlive = false;
            RetryGame();
        } 
       
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
}
