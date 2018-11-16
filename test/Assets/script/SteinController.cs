using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteinController : MonoBehaviour {

    [SerializeField]
    private float speed;

    Rigidbody2D myRb;

    private Vector2 direction;
    
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
  
    }


    
	
	// Update is called once per frame
	void FixedUpdate () {
        myRb.velocity = direction * speed;
	}

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    
}
