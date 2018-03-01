using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawn : MonoBehaviour
{

    public GameObject carPrefab;
    private float m_spawnDelay = 10.0f;
    private bool m_canSpawn = true;
    
	void Update ()
    {
        SpawnCar();
	}

    private void SpawnCar()
    {
        if(m_canSpawn == true)
        {
            GameObject car = Instantiate(carPrefab, transform.position, transform.rotation);
            StartCoroutine(SpawnDelay());
        }        
    }

    private IEnumerator SpawnDelay()
    {
        m_canSpawn = false;
        yield return new WaitForSeconds(m_spawnDelay);
        m_canSpawn = true;
    }

}
