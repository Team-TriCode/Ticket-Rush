using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Controller : MonoBehaviour {

    private string m_trigTag;
    private bool m_inside = false;
    private string m_colTag;

    private void Start()
    {
        m_trigTag = this.tag;
    }
    private void Update()
    {
        if(m_colTag == "Player" && m_inside == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Switch();
            } 
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        m_colTag = col.tag;
        m_inside = true;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        m_inside = false;
    }
    private void Switch()
    {
        switch (m_trigTag)
        {
            case "Elevator":

                Debug.Log("in code");
                GameObject liftPlat = GameObject.FindGameObjectWithTag("Lift_Platform");
                Lift_Controller liftController = liftPlat.GetComponent<Lift_Controller>();
                liftController.TurnOn();
                break;

            case "Elevator1":
                System.Console.WriteLine("bob");
                break;
            case "Elevator2":
                System.Console.WriteLine("bob");
                break;
            case "Elevator3":
                System.Console.WriteLine("bob");
                break;
            default:
                System.Console.WriteLine("bob");
                break;
        }
    }
}
