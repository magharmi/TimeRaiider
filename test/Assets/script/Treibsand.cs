using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Treibsand : MonoBehaviour {

    private GameObject spieler;
    private PlatformerCharacter2D script2D;
    private PlatformerCharacter script;

	void Start () {
        script2D = GameObject.FindGameObjectWithTag("spieler").GetComponent<PlatformerCharacter2D>();
        if(script2D == null){
            script = GameObject.FindGameObjectWithTag("spieler").GetComponent<PlatformerCharacter>();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spieler");
        {
            if(script2D == null){
                script.spielerGeschwindigkeit(5f); 
            }
            else{
                script2D.spielerGeschwindigkeit(5f);
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "spieler")
        { 
            if(script2D == null){
                script.spielerGeschwindigkeit(10f); 
            }
            else{
                script2D.spielerGeschwindigkeit(10f);
            } 
        }
    }
}
