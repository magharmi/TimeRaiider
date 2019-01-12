using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public int gold = 1;

    private GameControlScript control;

    public void Start()
    {
        control = GameObject.Find("lvlmanager").GetComponent<GameControlScript>();
    }

    void OnTriggerEnter2D (Collider2D col)
	{
        if (col.tag == "spieler")
        {
            control.addGold(gold);
            Debug.Log(gold + " Gold hinzugefügt");
            Destroy(gameObject);
        }
	}
}
