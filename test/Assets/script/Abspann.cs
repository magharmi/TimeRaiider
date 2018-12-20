using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Abspann : MonoBehaviour {

    private int bildNummer = 0;
    GameObject[] bilder;  

    void Start()
    {    
    }

    public void NächstesBild()
    {
        if(bildNummer == 0){
            bilder = GameObject.FindGameObjectsWithTag("Storiebild");
            Debug.Log("Erster Klick");
            Debug.Log("Anzahl der Bilder: " + bilder.Length );
            foreach(GameObject r in bilder){
                Debug.Log(r.gameObject); 
            }
        }
        Debug.Log("Klick " + bildNummer);
        bildNummer++;
        if(bildNummer < bilder.Length - 1){
            Destroy(GameObject.Find("00" + bildNummer));
        }
        else
        {
            Destroy(GameObject.Find("00" + bildNummer));
            Destroy(GameObject.Find("1"));
            Destroy(GameObject.Find("Text"));
        }
    }
}
