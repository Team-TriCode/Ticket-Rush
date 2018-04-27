﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{

    public float m_health = 100.0f; // Player health
    private int m_speed = 5; // Player movement speed multiplier
    private int m_jumpHeight = 300; // Player jump height
    private int m_swingForce = 15; // Force multiplier for swing object
    private bool m_isSwinging = false; // Check to see if player is currently interacting with swing object
    private bool m_isGrounded = true; // Check to see if player is grounded
    private bool m_canSwing = true; // Check to see if player can connect to swing object
    private bool m_isJumping = false;
    private Rigidbody2D m_player; // Player rigidbody
    private Vector3 m_ground; // Top right corner co-ordinate of groundcheck object
    private Vector3 m_ground2; // Bottom left corner co-ordinate of groundcheck object
    public LayerMask groundLayer; // Layer that is defined as ground to the player
    private Animator m_anim; // Player animation object
    private SpriteRenderer m_monkey; // Player sprite renderer
    private float m_xAxis; // Current X axis input
    private float m_yAxis; // Current Y axis input
    private bool m_playerDead = false;
    public Transform loseText;




    // Use this for initialization
    void Start()
    {

        m_monkey = this.GetComponent<SpriteRenderer>();
        m_anim = this.GetComponent<Animator>();
        m_player = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Keeps x and y inputs up to date

        m_yAxis = Input.GetAxis("Vertical");
        m_xAxis = Input.GetAxis("Horizontal");

        // Check direction character should be facing

        Look();

        // Checks whether player is currently interacting with a swing object

        if (m_playerDead == false)
        {
            if (m_isSwinging)
            {
                Swinging();
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = true;
                Move();
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rope" && m_canSwing == true)
        {
            m_isSwinging = true;
            m_canSwing = false;

            // Creates Hinge joint on player to allow swinging motion

            HingeJoint2D hinge = gameObject.AddComponent<HingeJoint2D>() as HingeJoint2D;
            hinge.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();

        }
    }
    IEnumerator Wait()
    {
        // Delays ability to reconnect to swing to stop issues with swing exit

        yield return new WaitForSeconds(0.1f);
        m_canSwing = true;
    }
    private void CheckGrounded()
    {

        // Check if the groundcheck object is overlapping the designated ground layer

        m_isGrounded = Physics2D.OverlapArea(m_ground, m_ground2, groundLayer);


    }
    private void Jump()
    {

        // Checks if player is grounded 

        if (m_isGrounded)
        {

            // Makes player jump

            m_player.AddForce(transform.up * m_jumpHeight);
            m_isJumping = true;

        }
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("Hit");

        // Takes damage from player health variable

        m_health -= damage;

        // Runs end game process when player has no more health

        if (m_health <= 0)
        {
            m_anim.SetInteger("State", 6);
            m_playerDead = true;
            m_player.velocity = new Vector3(0, m_player.velocity.y, 0);
            ShowGameOver();
            Invoke("PlayerLose", 2.5f);
        }
    }
    private void Move()
    {


        // Checks if player is in contact with the ground using the attached groundcheck object

        m_ground = GameObject.FindGameObjectWithTag("Groundcheck1").transform.position;
        m_ground2 = GameObject.FindGameObjectWithTag("Groundcheck2").transform.position;
        CheckGrounded();

        if (m_isGrounded == true)
        {
            m_isJumping = false;
        }
        Debug.Log(m_isGrounded);

        // Sets player animation dependent on current parameters

        if (!m_isGrounded)
        {
            m_anim.SetInteger("State", 2);
        }
        else if (m_isGrounded && m_xAxis != 0 && m_isJumping == false)
        {
            m_anim.SetInteger("State", 1);
        }
        else if (m_isGrounded && m_isJumping == false)
        {
            m_anim.SetInteger("State", 0);
        }

        // Allows player to jump on key press

        if (Input.GetKeyDown("space"))
        {
            Jump();
        }

        // Moves player accordingly to the x axis input

        m_player.velocity = new Vector3(m_speed * m_xAxis, m_player.velocity.y, 0);

    }
    private void Swinging()
    {
        // Disables collider

        GetComponent<BoxCollider2D>().enabled = false;
        m_anim.SetInteger("State", 4);

        // Adds force dependent on the current input values (using the horizantal axis)

        if (m_xAxis <= 0)
        {
            m_player.AddForce(transform.right * -m_swingForce * -m_xAxis);
        }

        else if (m_xAxis >= 0)
        {
            m_player.AddForce(transform.right * m_swingForce * m_xAxis);
        }

        // Disconnects swing when jump is pressed

        if (Input.GetButtonDown("Jump"))
        {
            m_isSwinging = false;
            m_anim.SetInteger("State", 5);
            Destroy(GetComponent<HingeJoint2D>());
            m_player.AddForce(transform.up * m_jumpHeight * m_yAxis);
            StartCoroutine(Wait());
        }

    }
    private void Look()
    {
        // Uses x axis to determine players direction of view

        if (m_xAxis < 0)
        {
            m_monkey.flipX = true;
        }

        else if (m_xAxis > 0)
        {
            m_monkey.flipX = false;
        }
    }
    private void ShowGameOver()
    {
        if (loseText.gameObject.activeInHierarchy == false)
        {
            loseText.gameObject.SetActive(true);
            Invoke("HideGameOver", 2.0f);
        }
    }

    private void HideGameOver()
    {
        if (loseText.gameObject.activeInHierarchy == true)
        {
            loseText.gameObject.SetActive(false);
        }
    }

    private void PlayerLose()
    {
        SceneManager.LoadScene("GameOver");
    }

}
