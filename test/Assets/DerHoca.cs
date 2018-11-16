using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerHoca : MonoBehaviour {
    Animator myAnim;
    Rigidbody2D rb;
   
	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("spieler"))
            {
                myAnim.SetTrigger("isHeilen");
                SoundManagerScript.PlaySound("Wulolo");
        }

        }
    

}
