using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBewegen : MonoBehaviour {

    private Vector3 startPos;
    private Vector3 newPos;

    public float speed;
    public float reichweite;
    public string richtung;

	// Use this for initialization
	void Start () {
        startPos = transform.position;

        //Zufällige Geschwindigkeit
       // speed = Random.Range(5f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
        if (richtung == "x")
        {
            newPos = startPos;
            newPos.x = newPos.x + Mathf.PingPong(Time.time * speed, reichweite);
        }
        if (richtung == "-x")
        {
            newPos = startPos;
            newPos.x = (newPos.x - Mathf.PingPong(Time.time * speed, reichweite));
        }
        if (richtung == "y")
        {
            newPos = startPos;
            newPos.y = newPos.y + Mathf.PingPong(Time.time * speed, reichweite);
        }

        if (richtung == "-y")
        {
            newPos = startPos;
            newPos.y = (newPos.y - Mathf.PingPong(Time.time * speed, reichweite));
        }

        if (richtung == "a")
        {
            newPos = startPos;
            newPos.x = newPos.x - Mathf.PingPong(Time.time * speed, reichweite) - 3;
           // newPos = startPos;
            newPos.y = newPos.y + Mathf.PingPong(Time.time * speed, reichweite) - 3;
        }

        if (richtung == "b")
        {
            newPos = startPos;
            newPos.x = newPos.x + Mathf.PingPong(Time.time * speed, reichweite) - 3;
            // newPos = startPos;
            newPos.y = newPos.y + Mathf.PingPong(Time.time * speed, reichweite) - 3;
        }

        if (richtung == "c")
        {
            newPos = startPos;
            newPos.x = newPos.x + Mathf.PingPong(Time.time * speed, reichweite) - 3;
            // newPos = startPos;
            newPos.y = newPos.y - Mathf.PingPong(Time.time * speed, reichweite) - 3;
        }


        if (richtung == "d")
        {
            newPos = startPos;
            newPos.x = newPos.x - Mathf.PingPong(Time.time * speed, reichweite) - 3;
            // newPos = startPos;
            newPos.y = newPos.y - Mathf.PingPong(Time.time * speed, reichweite) - 3;
        }

        transform.position = newPos;
	}
}
