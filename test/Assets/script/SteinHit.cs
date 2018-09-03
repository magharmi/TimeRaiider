﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteinHit : MonoBehaviour {

     public float weaponDamage;
  // projectileController myPc;
  // public GameObject steinEffekt;
	
        void Awake()
    {
        //myPc = GetComponentInParent< projectileController >();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            // myPc.removeForce();
            //Instantiate(steinEffect, transform.position, transform.rotation);
            //Destroy(gameObject);
            if(other.tag == "Enemy")
            {
                EnemyHealthBar hurtEnemy = other.gameObject.GetComponent<EnemyHealthBar>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            // myPc.removeForce();
            //Instantiate(steinEffect, transform.position, transform.rotation);
            //Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                EnemyHealthBar hurtEnemy = other.gameObject.GetComponent<EnemyHealthBar>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }
}
