using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_Spin : MonoBehaviour {

    public int speed = 50;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0,1 * Time.deltaTime * speed);
	}
}
