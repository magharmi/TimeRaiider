using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformersKampfTrigger : MonoBehaviour {

    private TransformersKampf controller;

	// Use this for initialization
	void Start () {
        controller = GameObject.Find("Transformers Kampf Controller").GetComponent<TransformersKampf>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "spieler")
        {
            controller.TransformersAngriff();
        }
    }
}
