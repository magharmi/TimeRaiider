using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler_Heilen : MonoBehaviour {

    public float healthAmount;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spieler")
        {
            Spieler_Leben gesundheit = collision.gameObject.GetComponent<Spieler_Leben>();
            gesundheit.addHealth(healthAmount);
            Destroy(gameObject);
        }
    }

}
