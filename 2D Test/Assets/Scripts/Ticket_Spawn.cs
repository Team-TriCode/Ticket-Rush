using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket_Spawn : MonoBehaviour
{
    public GameObject ticketPrefab;

    void Start ()
    {
        SpawnTicket();
    }
	
    private void SpawnTicket()
    {
        GameObject car = Instantiate(ticketPrefab, transform.position, transform.rotation);
    }
        
}
