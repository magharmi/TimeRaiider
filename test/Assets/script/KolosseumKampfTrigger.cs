using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolosseumKampfTrigger : MonoBehaviour {

    private KolosseumKampf kolosseumKampfController;

	// Use this for initialization
	void Start () {
        kolosseumKampfController = GameObject.Find("KampfController").GetComponent<KolosseumKampf>();
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "spieler")
        {
            kolosseumKampfController.sklavenSpawnenAufruf();
            Debug.Log("Trigger aktiviert");
            Destroy(gameObject);
        }
    }
}
