using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Manager : MonoBehaviour {

    public int points = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        UI_Manager ui = canvas.GetComponent<UI_Manager>();
        ui.AddScore(points);
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

}
