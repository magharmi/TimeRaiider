using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeuleAttackScript : MonoBehaviour {
    
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("spieler"))
        {
           // EnemyMovementController.charging = false;
          //  EnemyMovementController.isAttacking = true;
           
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("spieler"))
        {
            //SteinZeitMann.isAttacking = false;
         //   EnemyMovementController.charging = true;
        }
    }
    
}
