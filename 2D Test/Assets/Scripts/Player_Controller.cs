using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    private float m_health = 100.0f;
    private float m_speed = 5.0f;
    private float m_axisX;
    private float m_axisY;
    private float m_jumpPower = 300.0f;
    private Rigidbody2D m_rb2d;
    // Use this for initialization
    void Start ()
    {
        m_rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame

    private void Update()
    {
        PlayerMove();
        Jump();
    }
    
    private void PlayerMove()
    {
        m_axisX = Input.GetAxis("Horizontal");


        transform.Translate(new Vector2(m_axisX, m_axisY) * m_speed * Time.deltaTime);
    }
    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            m_rb2d.AddForce(Vector2.up * m_jumpPower);
        }

    }
    public void TakeDamage(float damage)
    {
        m_health -= damage;
        if(m_health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
