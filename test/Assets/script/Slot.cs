using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    private Inventory inventory;
    [SerializeField]
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("spieler").GetComponent<Inventory>();
    }

    public void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }
    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<ItemSpawnPos>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
            
    }
}
