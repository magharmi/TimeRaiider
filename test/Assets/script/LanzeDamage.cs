using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pfeil_Hit : MonoBehaviour {

    public float weaponDamage;


    ProjektilController myPc;

  //  public GameObject hitEffect;


    void Awake()
    {
        myPc = GetComponentInParent<ProjektilController>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("vurulabilir"))
        {
          //  myPc.removeForce();
          //  Insantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "enemy")
            {
            //    enemyHealth hitEnemy = other.gameObject.GetComponent<enemyHealth>();
              //  hitEnemy.addDamage(weaponDamage);
            }
        }
    }
}
