using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleBosskampfTrigger : MonoBehaviour
{


    private GameObject MainCamera, BosskampfKamera, BosskampfWand;

    // Use this for initialization
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        BosskampfKamera = GameObject.Find("Bosskampf Kamera");
        BosskampfWand = GameObject.Find("Bosskampf Wand");
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "spieler")
        {
            MainCamera.SetActive(false);
            BosskampfKamera.GetComponent<Camera>().enabled = true;
            BosskampfWand.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(gameObject);
        }
    }
}
