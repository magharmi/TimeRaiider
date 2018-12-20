using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rep_attack : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("CharacterRobotBoy"))
        {
            Rep.isAttacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("CharacterRobotBoy"))
        {
            Rep.isAttacking = false;
        }

    }
}
