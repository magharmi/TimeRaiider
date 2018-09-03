using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {
    public float alifeTime;
	// Use this for initialization
	void Awake () {
        //Einstellung life of Object
        Destroy(gameObject, alifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
