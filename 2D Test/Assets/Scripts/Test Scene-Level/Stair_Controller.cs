using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair_Controller : MonoBehaviour {
    private bool m_current = false;
	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<PolygonCollider2D>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Visible()
    {
        if(m_current == false)
        {
            m_current = true;
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<PolygonCollider2D>().enabled = true;
        }
        else if(m_current == true)
        {
            m_current = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<PolygonCollider2D>().enabled = false;
        }
        
    }
}
