using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leben : MonoBehaviour {
    public GameObject effect;
    private Transform spieler;
    float healthAmount;
    // Use this for initialization
    void Start () {
        spieler = GameObject.FindGameObjectWithTag("spieler").transform;
      
       
    }
	
	public void use()
    {
       
        Instantiate(effect, spieler.position, Quaternion.identity);
     
        Destroy(gameObject);
    }
}
