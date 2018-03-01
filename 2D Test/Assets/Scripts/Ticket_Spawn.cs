using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket_Spawn : MonoBehaviour {


    public GameObject ticketPrefab;
    // Use this for initialization
    void Start () {

        SpawnTicket();

    }
	
    private void SpawnTicket()
    {
        GameObject car = Instantiate(ticketPrefab, transform.position, transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
