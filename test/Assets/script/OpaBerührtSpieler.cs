using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpaBerührtSpieler : MonoBehaviour {

    private GameObject nächstesZiel;

	// Use this for initialization
	void Start () {
        nächstesZiel = GameObject.Find("Ziel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "spieler")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            nächstesZiel.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<DialogueTrigger>().enabled = true;
            gameObject.GetComponent<OpaBerührtSpieler>().enabled = false;
        }
    }
}
