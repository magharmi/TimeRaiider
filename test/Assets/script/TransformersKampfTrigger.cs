using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformersKampfTrigger : MonoBehaviour {

    public float sekunde = 1;

    private TransformersKampf controller;
    private bool kampfAktiviert = false;

    // Use this for initialization
    void Start () {
        controller = GameObject.Find("Transformers Kampf Controller").GetComponent<TransformersKampf>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "spieler")
        {
            StartCoroutine(warteSekunde(sekunde));
        }
    }

    IEnumerator warteSekunde(float sekunde)
    {
        yield return new WaitForSeconds(sekunde);
        if (kampfAktiviert == false)
        {
            kampfAktiviert = true;
            controller.TransformersAngriff();
        }
    }
}
