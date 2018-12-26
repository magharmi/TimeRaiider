using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landwirtkampf : MonoBehaviour
{
    private GameObject landwirt;

    // Use this for initialization
    void Start()
    {
        landwirt = GameObject.Find("Landwirt (1)");
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "spieler")
        {
            landwirt.GetComponent<GegnerAI>().enabled = true;
        }
    }
}