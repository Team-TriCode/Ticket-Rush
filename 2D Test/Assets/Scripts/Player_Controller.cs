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

    // Use this for initialization
    void Start()
    {
        m_rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            m_isGrounded = true;
            isJumping = false;
        }

    }

    // Update is called once per frame

    private void Update()
    {
        CheckGrounded();

        if (Input.GetKey(KeyCode.LeftArrow) && lookingRight == true)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            lookingRight = false;
        }

        if (Input.GetKey(KeyCode.RightArrow) && lookingRight == false)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            lookingRight = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            PlayerMove();
            notIdle = true;
        }
        
        if (notIdle == false)
        {
            anim.Play("PlayerIdle");
        }

        Jump();

    }

    private void PlayerMove()
    {
        m_axisX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(m_axisX, m_axisY) * m_speed * Time.deltaTime);

        if (isJumping == false)
        {
            anim.Play("PlayerWalking");
        }

    }

    // Performs jump unless player is grounded

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            notIdle = true;
            if (m_isGrounded)
            {
                m_rb2d.AddForce(Vector2.up * m_jumpPower);
                m_isGrounded = false;
                isJumping = true;
                anim.Play("PlayerJump");
            }

        }

    }
    public void TakeDamage(float damage)
    {
        m_health -= damage;
        if (m_health <= 0)
        {
            Debug.Log("GameOver");
        }
    }

    private void CheckGrounded()
    {
        if (m_isGrounded)
        {
            notIdle = false;
        }
    }

    //private void CheckGrounded()
    //{
    //    m_ground = GameObject.Find("Groundcheck").transform.position;
    //    m_ground2 = GameObject.Find("Groundcheck2").transform.position;
    //    m_isGrounded = Physics2D.OverlapArea(m_ground, m_ground2, groundLayer);

    //    if (m_isGrounded == true)
    //    {
    //        notIdle = false;
    //    }
    //}
}
