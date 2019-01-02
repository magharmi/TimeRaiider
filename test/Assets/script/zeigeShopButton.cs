using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeigeShopButton : MonoBehaviour {

    private GameObject button;
    
	// Use this for initialization
	void Start () {
        button = GameObject.Find("GoToShop");
        button.SetActive(false);
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spieler")
        {
            Debug.Log("Zeige Button");
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "spieler")
        {
            Debug.Log("Verstecke Button");
            button.SetActive(false);
        }
    }
}
