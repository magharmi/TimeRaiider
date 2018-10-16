using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treibsand : MonoBehaviour {

    private GameObject spieler;

	// Use this for initialization
	void Start () {
        spieler = GameObject.FindGameObjectWithTag("spieler");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "spieler")
        {
            spieler.GetComponent<PlatformerCharacter>().spielerGeschwindigkeit(5);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

        spieler.GetComponent<PlatformerCharacter>().spielerGeschwindigkeit(10);
        
    }
}
