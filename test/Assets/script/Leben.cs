using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leben : MonoBehaviour {
    public GameObject effect;
    private Transform spieler;
    float healthAmount=5;
    // Use this for initialization
    void Start () {
        spieler = GameObject.FindGameObjectWithTag("spieler").transform;
      
       
    }
	
	public void use()
    {
        Spieler_Leben gesundheit = GetComponent<Spieler_Leben>();
        Instantiate(effect, spieler.position, Quaternion.identity);
        gesundheit.addHealth(healthAmount);
        Destroy(gameObject);
    }
}
