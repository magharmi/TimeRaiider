using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gegner : MonoBehaviour {

    public lvlmanager Lvlmanager;
    public Vector3 startPos;
      public Vector3 newPos;
    public Vector3 tempPos;
    public float speed;
    public SpriteRenderer sr;
    public bool hit = true;
    public float weg = 6;
    public int leben = 100;
    public GameObject bloodEffect;
 
    // Use this for initialization
    void Start ()
    {
        Lvlmanager = FindObjectOfType<lvlmanager>();
        startPos = transform.position;
        //Zufällige Geschwindigkeit generieren
        speed = Random.Range(5f, 8f);
        tempPos = startPos;
        sr = gameObject.GetComponent<SpriteRenderer>();
	}

    private void Update()
    {
        newPos = startPos;
        newPos.x = newPos.x + Mathf.PingPong(Time.time * speed, weg) - 3;

        transform.position = newPos;

        //Bewegung positiv
        if(newPos.x > tempPos.x){
            sr.flipX = true;
        }
        //Bewegung negativ
        else
        {
            sr.flipX = false;
        }

        tempPos = newPos;
    }

    //gegner berührt andere objekte
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "spieler" && hit == true)
        {
            Lvlmanager.RespawnSpieler();
            Debug.Log("geht nicht mehr");
            hit = false;
            StartCoroutine(FreezePlayer());
        }


        if (other.gameObject.tag == "bullet")
        {
            leben -= 10;
            
            if (leben == 0)
            {
                Destroy(gameObject, 0.2f);
                Instantiate(bloodEffect, transform.position, Quaternion.identity);
            }
            //Destroy(gameObject, 0.2f);
            Destroy(other.gameObject,0f);
        }
    }

   

    IEnumerator FreezePlayer()
    {
        //kann so lange kein schade vom gleichen gegner bekommen
        //wenn hit im managerscript, dann kann man ganz unverwundbar sein
        yield return new WaitForSeconds(1);
        hit = true;
        Debug.Log("geht wieder");
     }
    
}
