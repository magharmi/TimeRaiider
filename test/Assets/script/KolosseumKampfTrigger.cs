using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolosseumKampfTrigger : MonoBehaviour {

    public KolosseumKampf kolosseumKampfController;

	// Use this for initialization
	void Start () {
        kolosseumKampfController = GetComponent<KolosseumKampf>();
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
