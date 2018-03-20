using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    private float m_health = 100.0f;
    private float m_speed = 5.0f;
    private float m_axisX;
    private float m_axisY;
    private float m_jumpPower = 300.0f;
    private bool m_isGrounded = false;
    private bool notIdle = false;
    private bool lookingRight = true;
    private Vector3 m_ground;
    public LayerMask groundLayer;
    private Rigidbody2D m_rb2d;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        m_rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
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
        else
        {
            notIdle = false;
        }

        Jump();
    }

    private void PlayerMove()
    {
        m_axisX = Input.GetAxis("Horizontal");

        m_ground = GameObject.Find("Groundcheck").transform.position;
        transform.Translate(new Vector2(m_axisX, m_axisY) * m_speed * Time.deltaTime);
        anim.Play("PlayerWalking");

    }

    // Performs jump unless player is grounded

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (m_isGrounded)
            {
                m_rb2d.AddForce(Vector2.up * m_jumpPower);
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
        RaycastHit2D hit = Physics2D.Raycast(m_ground, -Vector2.up, groundLayer);

        if (hit.distance > 1)
        {
            m_isGrounded = false;
        }
        else if (hit.distance <= 1)
        {
            m_isGrounded = true;
            if(notIdle == false)
            {
                anim.Play("PlayerIdle");
            }
        }
    }
}
