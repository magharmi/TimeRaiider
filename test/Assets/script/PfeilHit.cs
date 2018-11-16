using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PfeilHit : MonoBehaviour {

    public float weaponDamage;


    ArmbrustGeschoss myPc;

    public GameObject hitEffect;


    void Awake()
    {
        myPc = GetComponentInParent<ArmbrustGeschoss>();
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
        //    myPc.removeForce();
          
             Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "enemy")
            {
                EnemyHealthBar hitEnemy = other.gameObject.GetComponent<EnemyHealthBar>();
               hitEnemy.addDamage(weaponDamage);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
           // myPc.removeForce();
            
            //  Insantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "enemy")
            {
                EnemyHealthBar hitEnemy = other.gameObject.GetComponent<EnemyHealthBar>();
                //    enemyHealth hitEnemy = other.gameObject.GetComponent<enemyHealth>();
                hitEnemy.addDamage(weaponDamage);
            }
        }
    }
}
