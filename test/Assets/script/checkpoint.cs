using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {

    public lvlmanager Lvlmanager;

	// Use this for initialization
	void Start ()
    {
        Lvlmanager = FindObjectOfType<lvlmanager>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spieler");
        {
            Debug.Log("checkpoint");
            //neuen checkpoint abspeichern
          //  Lvlmanager.currentCheckpoint = gameObject;
            
        }
    }



}
