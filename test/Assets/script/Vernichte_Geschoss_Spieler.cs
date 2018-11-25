using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vernichte_Geschoss_Spieler : MonoBehaviour {


    public float lifeTime;
    // Use this for initialization

    void Awake () {
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
