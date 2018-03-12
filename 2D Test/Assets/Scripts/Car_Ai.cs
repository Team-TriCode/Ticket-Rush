using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Ai : MonoBehaviour
{

    private float m_damage = 100.0f;
    private float m_speed = 5.0f;
    private float m_axisY;    
	
	void Update()
    {
        CarMove();
	}

    private void CarMove()
    {
        transform.Translate(new Vector2(-m_speed, m_axisY) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Controller controller = collision.gameObject.GetComponent<Player_Controller>();
        controller.TakeDamage(m_damage);
    }

}
