using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnPos : MonoBehaviour {
    public GameObject item;
    private Transform spieler;
	// Use this for initialization
	void Start () {
        spieler = GameObject.FindGameObjectWithTag("spieler").transform; 
	}
	
public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(spieler.position.x , spieler.position.y );
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
