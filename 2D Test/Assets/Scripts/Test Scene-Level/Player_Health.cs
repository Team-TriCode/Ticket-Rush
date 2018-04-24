using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {

    public Player_Controller pc;
    private Image healthBar;

    public Sprite fullHealth;
    public Sprite twoThirdsHealth;
    public Sprite thirdHealth;
    public Sprite noHealth;


    // Use this for initialization
    void Start ()
    {
        healthBar = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (pc.m_health <= 0)
        {
            healthBar.sprite = noHealth;
        }
        else if (pc.m_health <= 34)
        {
            healthBar.sprite = thirdHealth;
        }
        else if (pc.m_health <= 66)
        {
            healthBar.sprite = twoThirdsHealth;
        }
        else
        {
            healthBar.sprite = fullHealth;
        }
    }
}
