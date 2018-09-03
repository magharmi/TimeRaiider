using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintergrundZerstören : MonoBehaviour {

    public GameObject[] hintergründe;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "spieler")
        {
            Debug.Log("SPIELER ERKANNT");
            for(int i = 0; i < hintergründe.Length; i++)
            {
                Destroy(hintergründe[i]);
            }
        }
    }
}
