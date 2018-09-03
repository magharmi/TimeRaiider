using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteinController : MonoBehaviour {
   
    Rigidbody2D myRb;
    public float  velX = 5f;
    private float velY = 0f;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

	
	// Update is called once per frame
	void Update () {
        myRb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
	}
}
