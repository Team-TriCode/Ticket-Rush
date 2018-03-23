using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private float m_health = 100.0f;
    private float m_speed = 5.0f;
    private float m_axisX;
    private float m_axisY = 0.0f;
    private float m_jumpPower = 300.0f;

    private bool m_isGrounded = true;
    private bool notIdle = false;
    private bool isJumping = false;
    private bool lookingRight = true;

    private Vector3 m_ground;
    private Vector3 m_ground2;
    public LayerMask groundLayer;
    private Rigidbody2D m_rb2d;
    private Animator anim;
    

    void Start()
    {
        m_rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }    
    

    private void Update()
    {
        CheckGrounded();

        // Animation controller for moving left
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && lookingRight == true)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            lookingRight = false;
        }

        // Animation controller for moving right
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && lookingRight == false)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            lookingRight = true;
        }

        // Movement controller for A, D, Left Arrow and Right Arrow
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            PlayerMove();
            notIdle = true;
        }
        
        // Animation controller for idling
        if (notIdle == false)
        {
            anim.Play("PlayerIdle");
        }

        Jump();
    }


    // Takes horizontal axis value and transforms the player position accordingly
    private void PlayerMove()
    {
        m_axisX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(m_axisX, m_axisY) * m_speed * Time.deltaTime);

        if (isJumping == false)
        {
            anim.Play("PlayerWalking");
        }

    }


    // Performs jump unless player is in the air
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && m_isGrounded)
        {
            notIdle = true;
            m_rb2d.AddForce(Vector2.up * m_jumpPower);
            m_isGrounded = false;
            isJumping = true;            
        }
    }


    // When player collides with floor, is grounded is true
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            m_isGrounded = true;
            isJumping = false;
        }
    }


    // When player stops colliding with floor, is grounded is false, and player jump/fall anim plays
    private void OnCollisionExit2D(Collision2D collision)
    {
        m_isGrounded = false;
        isJumping = true;
        anim.Play("PlayerJump");
    }


    // Player takes damage until health is 0, then its Game Over
    public void TakeDamage(float damage)
    {
        m_health -= damage;
        if (m_health <= 0)
        {
            Debug.Log("GameOver");
        }
    }


    // If player is grounded, idle
    private void CheckGrounded()
    {        
        if (m_isGrounded)
        {
            notIdle = false;
        }
    }
}
