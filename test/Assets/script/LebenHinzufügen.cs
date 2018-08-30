using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LebenHinzufügen : MonoBehaviour {

    public lvlmanager lvlmanager;

    private bool isColliding = false;

	// Use this for initialization
	void Start () {
        lvlmanager = FindObjectOfType<lvlmanager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "spieler")
        {
            if (isColliding)
            {
                return;
            }
            isColliding = true;
            Destroy(gameObject);
            lvlmanager.LebenErhöhen(1);
        }
    }
}
