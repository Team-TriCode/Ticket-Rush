using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift_Controller : MonoBehaviour {

    public GameObject startObj;
    public GameObject targetObj;
    private Vector3 m_originPos;
    private Vector3 m_targetPos;
    private Vector3 m_nextPos;
    private bool m_on = false;
    private bool m_moved = false;
    private float m_speed = 1.00f;

    private void Start()
    {
        m_targetPos = targetObj.transform.position;
        m_originPos = startObj.transform.position;
        m_nextPos = targetObj.transform.position;
    }
    private void Update()
    {
        if(m_on)
        {
            Move();
        }
    }
    public void TurnOn()
    {
        m_on = true;
    }
    public void Move()
    {
        
        if(startObj.transform.position != m_nextPos)
        {
            startObj.transform.position = Vector3.MoveTowards(startObj.transform.position, m_nextPos, m_speed * Time.deltaTime);
        }
        else if(m_moved == false)
        {
            m_moved = true;
            m_nextPos = m_originPos;
        }
        else if(m_moved == true)
        {
            m_moved = false;
            m_nextPos = m_targetPos;
        }
            
    }

}
