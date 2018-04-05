using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private float m_health = 100.0f;
    private int m_speed = 5;
    private int m_jumpHeight = 300;
    private int m_swingForce = 25;

    private bool m_isSwinging = false;
    private bool m_isGrounded = true;
    private bool m_canSwing = true;
    private bool m_look = false;

    private Rigidbody2D m_player;
    private Vector3 m_ground;
    private Vector3 m_ground2;
    public LayerMask groundLayer;
    private Animator m_anim;
    private SpriteRenderer m_monkey;   
        
    void Start()
    {
        m_monkey = this.GetComponent<SpriteRenderer>();
        m_anim = this.GetComponent<Animator>();
        m_player = this.GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        m_ground = GameObject.FindGameObjectWithTag("Groundcheck1").transform.position;
        m_ground2 = GameObject.FindGameObjectWithTag("Groundcheck2").transform.position;
        CheckGrounded();

        if (m_isSwinging == false)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            m_anim.SetInteger("State", 0);
            if (Input.GetButton("A"))
            {
                if (m_look == false)
                {
                    m_look = true;
                    m_monkey.flipX = true;
                }

                m_anim.SetInteger("State", 1);
                m_player.velocity = new Vector3(-m_speed, m_player.velocity.y, 0);

                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }
            }
            else if (Input.GetButton("D"))
            {
                if (m_look == true)
                {
                    m_look = false;
                    m_monkey.flipX = false;
                }
                m_anim.SetInteger("State", 1);
                m_player.velocity = new Vector3(m_speed, m_player.velocity.y, 0);


                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }
            }
            else if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            else
            {
                m_player.velocity = new Vector3(0, m_player.velocity.y, 0);
            }
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;

            if (Input.GetButton("A"))
            {
                m_player.AddForce(transform.right * -m_swingForce);
            }

            if (Input.GetButton("D"))
            {
                m_player.AddForce(transform.right * m_swingForce);
            }

            if (Input.GetButtonDown("Jump"))
            {
                m_isSwinging = false;
                Destroy(GetComponent<HingeJoint2D>());
                m_player.AddForce(transform.up * m_jumpHeight);
                StartCoroutine(Wait());
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rope" && m_canSwing == true)
        {
            m_isSwinging = true;
            m_canSwing = false;

            //attach to rope
            HingeJoint2D hinge = gameObject.AddComponent<HingeJoint2D>() as HingeJoint2D;
            hinge.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();

        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        m_canSwing = true;
    }
    private void CheckGrounded()
    {
        Debug.Log(m_ground);
        Debug.Log(m_ground2);
        Debug.Log(m_isGrounded);
        m_isGrounded = Physics2D.OverlapArea(m_ground, m_ground2, groundLayer);
        

    }
    private void Jump()
    {
        if (m_isGrounded)
        {
            
            m_player.AddForce(transform.up * m_jumpHeight);
            m_anim.SetInteger("State", 2);

        }
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Hit");
        m_health -= damage;
        if (m_health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
