using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino1Attack : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("spieler"))
        {
         //   Enemy.isAttacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("spieler"))
        {
        //    Enemy.isAttacking = false;
        }
    }
}
