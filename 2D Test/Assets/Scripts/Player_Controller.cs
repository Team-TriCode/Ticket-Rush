using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{    
    public float m_health = 100.0f;
    private int m_speed = 5;
    private int m_jumpHeight = 210;
    private int m_swingForce = 10;

    private float m_xAxis;
    private float m_yAxis;

    private bool m_isSwinging = false;
    private bool m_isGrounded;
    private bool m_canSwing = true;
    private bool m_isJumping = false;

    public LayerMask groundLayer;
    public Transform loseText;

    private Rigidbody2D m_player;    
    private Animator m_anim;
    private SpriteRenderer m_playerRenderer;   
    
        
    void Start()
    {
        m_playerRenderer = this.GetComponent<SpriteRenderer>();
        m_anim = this.GetComponent<Animator>();
        m_player = this.GetComponent<Rigidbody2D>();
    }    

    void Update()
    {
        m_yAxis = Input.GetAxis("Vertical");
        m_xAxis = Input.GetAxis("Horizontal");

        Look();

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

    private void Move()
    {
        if (IsGrounded())
        {
            m_isJumping = false;
        }

        if (!IsGrounded()) // When player is in the air
        {
            m_anim.SetInteger("State", 2);
        }
        else if (IsGrounded() && m_xAxis != 0 && m_isJumping == false) // When player is moving and touching the ground
        {
            m_anim.SetInteger("State", 1);
        }
        else if (IsGrounded() && m_isJumping == false) // When player is idle
        {
            m_anim.SetInteger("State", 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        m_player.velocity = new Vector3(m_speed * m_xAxis, m_player.velocity.y, 0);
    }

    // Update the direction character should be facing
    private void Look()
    {
        if (m_xAxis < 0)
        {
            m_playerRenderer.flipX = true;
        }
        else if (m_xAxis > 0)
        {
            m_playerRenderer.flipX = false;
        }
    }

    // Swinging Method
    public void Swinging()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        m_anim.SetInteger("State", 4);

        if (m_xAxis <= 0)
        {
            m_player.AddForce(transform.right * -m_swingForce);
        }
        if (m_xAxis >= 0)
        {
            m_player.AddForce(transform.right * m_swingForce);
        }

        if (Input.GetButtonDown("Jump"))
        {
            m_isSwinging = false;
            m_anim.SetInteger("State", 5);
            Destroy(GetComponent<HingeJoint2D>());
            m_player.AddForce(transform.up * m_jumpHeight * m_yAxis);
            StartCoroutine(Wait());
        }
    }

    // OnCollision Method
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision with Rope
        if (collision.gameObject.tag == "Rope" && m_canSwing == true)
        {
            m_isSwinging = true;
            m_canSwing = false;

            // Attach to rope
            HingeJoint2D hinge = gameObject.AddComponent<HingeJoint2D>() as HingeJoint2D;
            hinge.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();                        
        }   
    }

    // IsGrounded Method
    private bool IsGrounded()
    {
        Vector2 position = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 0.9f, groundLayer);

        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    // Jump Method
    private void Jump()
    {
        if (IsGrounded())
        {
            m_player.AddForce(transform.up * m_jumpHeight);
            m_anim.SetInteger("State", 2);            
        }
    }

    // TakeDamage Method
    public void TakeDamage(float damage)
    {
        Debug.Log("Hit");
        m_health -= damage;
        if (m_health <= 0)
        {
            ShowGameOver();
            Invoke("PlayerLose", 2.5f);
        }
    }    

    // SwingWait Method
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        m_canSwing = true;
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
