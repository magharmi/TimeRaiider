using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZielItemNächsterAkt : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "spieler")
        {
            SceneManager.LoadScene("Feld");
        }
    }
}
