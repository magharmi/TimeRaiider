using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisSteineSchaden : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D boden)
    {
        if (boden.gameObject.tag == "boden")
        {
            gameObject.GetComponent<Spieler_Wierd_Verletzt>().damage = 0;
        }
    }
}
