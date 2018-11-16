using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmbrustGeschoss : MonoBehaviour {

    [SerializeField] float pfeilSpeed;
    Rigidbody2D myRb;


    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
            myRb.AddForce(new Vector2(-1, 0) * pfeilSpeed, ForceMode2D.Impulse);
        else
        {
            myRb.AddForce(new Vector2(1, 0) * pfeilSpeed, ForceMode2D.Impulse);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
