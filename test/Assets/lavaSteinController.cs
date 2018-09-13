using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaSteinController : MonoBehaviour {

    public float lavaSteinSpeedHigh;
    public float lavaSteinSpeedLow;
    public float lavaRichtung;
    Rigidbody2D lavaSteinRb;
    public float lavaTurkAngle;


	// Use this for initialization
	void Start () {
        lavaSteinRb = GetComponent<Rigidbody2D>();
        lavaSteinRb.AddForce(new Vector2(Random.Range(-lavaRichtung, lavaRichtung), Random.Range(lavaSteinSpeedLow,lavaSteinSpeedHigh)),ForceMode2D.Impulse);
        lavaSteinRb.AddTorque((Random.Range(-lavaTurkAngle, lavaTurkAngle)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
