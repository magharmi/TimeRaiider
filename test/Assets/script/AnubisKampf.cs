using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisKampf : MonoBehaviour {

    private GameObject anubis;
    private Vector3 startPosition;
    private bool anubisZurück = false;
    private bool mumienSpawnen = false;
    private GameObject[] mumien;

    // Use this for initialization
    void Start () {
        anubis = GameObject.FindGameObjectWithTag("Boss");
        mumien = GameObject.FindGameObjectsWithTag("AnubisMumien");
        startPosition = anubis.transform.position;
}
	
	// Update is called once per frame
	void Update () {
		if(anubis.GetComponent<GegnerAI>().leben == 350)
        {
            if (anubisZurück == false)
            {
                anubis.GetComponent<BoxCollider2D>().enabled = false;
                anubis.GetComponent<GegnerAI>().speed = 0;
                anubis.transform.position = Vector2.MoveTowards(anubis.transform.position, startPosition, 7 * Time.deltaTime);
                if (anubis.transform.position == startPosition)
                {
                    Debug.Log("Anubis zurück");
                    anubisZurück = true;
                    mumienSpawnen = true;
                    anubis.GetComponent<GegnerAI>().leben = 350;
                }
            }
            else if (mumienSpawnen == true)
            {
                mumienSpawnenFunc();
                Debug.Log("Mumien spawnen");
                mumienSpawnen = false;
            }
        }
	}

    public void ersterAnubisAngriff()
    {
        anubis.GetComponent<GegnerAI>().speed = 5;
    }

    public void mumienSpawnenFunc()
    {
        StartCoroutine(warten(mumien.Length-1));
    }

    IEnumerator warten(int mumienNummer)
    {
        mumien[mumienNummer].GetComponent<SpriteRenderer>().enabled = true;
        mumien[mumienNummer].GetComponent<GegnerAI>().enabled = true;
        yield return new WaitForSeconds(2);
        if(mumienNummer == 8)
        {
            StartCoroutine(warten(mumienNummer - 1));
            StartCoroutine(warten(mumienNummer - 2));
        }
        else if(mumienNummer > 0)
        {
            StartCoroutine(warten(mumienNummer - 1));
        }
    }

}
