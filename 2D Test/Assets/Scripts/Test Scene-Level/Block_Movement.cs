using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Movement : MonoBehaviour {

    private float m_distance = 1.0f;
    public LayerMask boxMask;
    private GameObject m_box;
    
	
	void Update ()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, m_distance, boxMask);
        if(hit.collider != null && hit.collider.tag == "pushable" && Input.GetKey(KeyCode.E))
        {
            m_box = hit.collider.gameObject;
            m_box.GetComponent<FixedJoint2D>().enabled = true;
            m_box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();

        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            m_box.GetComponent<FixedJoint2D>().enabled = false;
        }
	}
    
}
