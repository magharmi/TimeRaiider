using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;
    // Use this for initialization
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("spieler").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spieler"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {


                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);

                   
                    Destroy(gameObject);
                    
                    break;
                }
            }
        }
    }
}
