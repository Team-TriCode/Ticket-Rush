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

    private Transform m_groundCheck;
    public LayerMask floorMask;
    private bool m_grounded;

    private Rigidbody2D m_rb2d;
       

    void Start ()
    {
        m_rb2d = gameObject.GetComponent<Rigidbody2D>();
        m_groundCheck = GameObject.Find("Groundcheck").GetComponent<Transform>();
	}    

    private void Update()
    {
        PlayerMove();
        Jump();
    }

    //Check if gameobject Groundcheck is overlapping anything with specified layermask
    private void FixedUpdate()
    {
        m_grounded = Physics2D.OverlapCircle(m_groundCheck.position, 0.5f, floorMask);
    }

    private void PlayerMove()
    {
        m_axisX = Input.GetAxis("Horizontal");


        transform.Translate(new Vector2(m_axisX, m_axisY) * m_speed * Time.deltaTime);
    }

    // Performs jump only when player is grounded
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && m_grounded)
        {
            m_rb2d.AddForce(Vector2.up * m_jumpPower);                     
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

}
