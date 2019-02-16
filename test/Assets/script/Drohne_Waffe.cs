using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drohne_Waffe : MonoBehaviour {
    Transform player;
    public float offset;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("spieler").transform;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 difference =  player.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ*offset*player.position.x);
    }
}
