using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Man_Attack : MonoBehaviour {

void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("CharacterRobotBoy")){
            HoelenMenschGeht.isAttacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("CharacterRobotBoy"))
        {
            HoelenMenschGeht.isAttacking = false;
        }

    }
}
