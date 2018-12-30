using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    private GameControlScript control;

    public void Start()
    {
        control = GameObject.Find("lvlmanager").GetComponent<GameControlScript>();
    }

    void OnTriggerEnter2D (Collider2D col)
	{
		GameControlScript.moneyAmount += 1;
        control.addEP(10);
		Destroy (gameObject);
	}
}
