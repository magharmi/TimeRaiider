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
            if (leben != 0)
            {
                GameObject.Find("CharacterRobotBoy").GetComponent<Spieler_Leben>().addHealth(lebenAnzahl);
                Debug.Log("Spieler geheilt");
                Destroy(gameObject);
            }
            else
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        Debug.Log("aufheben");
                        inventory.isFull[i] = true;
                        Instantiate(itemButton, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }
}
