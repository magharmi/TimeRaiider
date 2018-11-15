using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaheimKampfTrigger : MonoBehaviour
{

    private DaheimKampf daheimKampfController;

    // Use this for initialization
    void Start()
    {
        daheimKampfController = GameObject.Find("KampfController").GetComponent<DaheimKampf>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "spieler")
        {
            daheimKampfController.agentenSpawnenAufruf();
            Debug.Log("Trigger aktiviert");
            Destroy(gameObject);
        }
    }
}
