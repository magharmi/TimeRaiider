using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackforce;
   
    float nextDamage;

	// Use this for initialization
	void Start () {
        nextDamage = 0f;
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag=="spieler" && nextDamage < Time.time){
            
            Spieler_Leben spielerleben = other.gameObject.GetComponent<Spieler_Leben>();
            spielerleben.addDamage(damage);
            nextDamage = Time.time + damageRate;
          
            PushBack(other.transform);
        }
    }

    void PushBack(Transform pushedObject)
    {
        Vector2 pushRichtung = new Vector2(0, pushedObject.position.y - transform.position.y).normalized;
        pushRichtung *= pushBackforce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushRichtung, ForceMode2D.Impulse);
    }
}
