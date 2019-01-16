using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxkampfTrigger : MonoBehaviour {


    private GameObject MainCamera, BosskampfKamera, BosskampfWand, Landwirt;

	// Use this for initialization
	void Start () {
        MainCamera = GameObject.Find("Main Camera");
        BosskampfKamera = GameObject.Find("Bosskampf Kamera");
        BosskampfWand = GameObject.Find("Bosskampf Wand");
        Landwirt = GameObject.Find("Landwirt (2)");
	}
	

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "spieler")
        {
            //Landwirt.GetComponent<SpriteRenderer>().enabled = true;
            MainCamera.SetActive(false);
            BosskampfKamera.GetComponent<Camera>().enabled = true;
            BosskampfWand.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(gameObject);
        }
    }
}
