using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteineZerstoerbar : MonoBehaviour {
    public GameObject[] steine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "spieler")
        {
            for(int i = 0; i < steine.Length; i++)
            {
                steine[i].layer = 11;
            }
            Destroy(gameObject);
        }
    }
}
