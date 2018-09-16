using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerTotErfüllt : MonoBehaviour {

    public BoxCollider2D altesZiel = null;
    public BoxCollider2D neuesZiel;

    private GegnerAI gegnerEigenschaften;

    // Use this for initialization
    void Start () {
        gegnerEigenschaften = gameObject.GetComponent<GegnerAI>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gegnerEigenschaften.leben == 0)
        {
            Debug.Log("Gegner tot");
            Destroy(altesZiel);
            neuesZiel.enabled = true;
        }
	}
}
