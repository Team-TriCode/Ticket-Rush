using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Damage : MonoBehaviour
{
    private float m_damage = 34.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Controller controller = collision.gameObject.GetComponent<Player_Controller>();
        controller.TakeDamage(m_damage);
    }
}
