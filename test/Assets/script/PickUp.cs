using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public GameObject itemButton;
    public float lebenAnzahl = 20;

    private Inventory inventory;
    private float leben;

    // Use this for initialization
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("spieler").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spieler"))
        {
            GameObject.Find("CharacterRobotBoy").GetComponent<Spieler_Leben>().addHealth(lebenAnzahl);
            Debug.Log("Spieler geheilt");
            Destroy(gameObject);
        }
    }
}
