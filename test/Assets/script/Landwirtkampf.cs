using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landwirtkampf : MonoBehaviour
{
    private GameObject landwirt;

    // Use this for initialization
    void Start()
    {
        landwirt = GameObject.Find("Landwirt (2)");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spieler")) {
            landwirt.GetComponent<GegnerAI>().enabled = true;
            Debug.Log("Starte Kampf");
        }
    }
}