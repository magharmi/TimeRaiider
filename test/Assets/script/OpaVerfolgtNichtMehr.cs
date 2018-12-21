using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpaVerfolgtNichtMehr : MonoBehaviour {

    private GameObject opa;

	// Use this for initialization
	void Start () {
        opa = GameObject.Find("Grossvater");
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        opa.GetComponent<GegnerAI>().enabled = false;
    }
}
