using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerTotErfüllt : MonoBehaviour {

    public BoxCollider2D altesZiel = null;
    public BoxCollider2D neuesZiel;
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<EnemyHealthBar>().currentHealth <= 10)
        {
            Debug.Log("Gegner tot");
            Destroy(altesZiel);
            neuesZiel.enabled = true;
        }
	}
}
