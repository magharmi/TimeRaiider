using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolosseumKampf : MonoBehaviour
{

    private GameObject champion, kampfKamera, mainCamera, unsichtbareWand;
    private Vector3 startPosition;
    private bool anubisZurück = false;
    private bool mumienSpawnen = false;
    private bool leben350 = true;
    private bool leben200 = false;
    private bool leben0 = false;
    private GameObject[] sklaven, mumien2;

    // Use this for initialization
    void Start()
    {
        champion = GameObject.FindGameObjectWithTag("Boss");
        sklaven = GameObject.FindGameObjectsWithTag("AnubisMumien");
        mumien2 = GameObject.FindGameObjectsWithTag("AnubisMumien2");
        kampfKamera = GameObject.Find("Kampf Kamera");
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (leben200 == true)
        {
            if (champion.GetComponent<GegnerAI>().leben == 200)
            {
                if (anubisZurück == false)
                {
                    champion.GetComponent<BoxCollider2D>().enabled = false;
                    champion.GetComponent<GegnerAI>().speed = 0;
                    champion.transform.position = Vector2.MoveTowards(champion.transform.position, startPosition, 7 * Time.deltaTime);
                    if (champion.transform.position == startPosition)
                    {
                        Debug.Log("Anubis zurück");
                        anubisZurück = true;
                        mumienSpawnen = true;
                        champion.GetComponent<GegnerAI>().leben = 200;
                    }
                }
                else if (mumienSpawnen == true)
                {
                    loewenTigerSpawnenAufruf();
                    Debug.Log("Mumien spawnen");
                    mumienSpawnen = false;
                    leben200 = false;
                    leben0 = true;
                }
            }
        }
        else if (leben0 == true)
        {
            if (champion.GetComponent<GegnerAI>().leben == 0)
            {
                kampfKamera.GetComponent<Camera>().enabled = false;
                mainCamera.GetComponent<Camera>().enabled = true;
                unsichtbareWand.SetActive(false);
                leben0 = false;
            }
        }
    }

    public void sklavenSpawnenAufruf()
    {
        StartCoroutine(sklavenSpawnenFunc(sklaven.Length - 1));
    }

    IEnumerator sklavenSpawnenFunc(int sklavenNummer)
    {
        sklaven[sklavenNummer].GetComponent<SpriteRenderer>().enabled = true;
        sklaven[sklavenNummer].GetComponent<GegnerAI>().enabled = true;
        yield return new WaitForSeconds(2);
        if (sklavenNummer <= 8)
        {
            StartCoroutine(sklavenSpawnenFunc(sklavenNummer - 1));
            StartCoroutine(sklavenSpawnenFunc(sklavenNummer - 2));
        }
        else if (sklavenNummer > 8)
        {
            StartCoroutine(sklavenSpawnenFunc(sklavenNummer - 1));
        }
        if (sklavenNummer == 0)
        {
            yield return new WaitForSeconds(5);
            loewenTigerSpawnenAufruf();
        }
    }

    public void loewenTigerSpawnenAufruf()
    {
        StartCoroutine(loewenTigerSpawnen(sklaven.Length - 1));
    }

    IEnumerator loewenTigerSpawnen(int loeweTigerNummer)
    {
        mumien2[loeweTigerNummer].GetComponent<SpriteRenderer>().enabled = true;
        mumien2[loeweTigerNummer].GetComponent<GegnerAI>().enabled = true;
        yield return new WaitForSeconds(2);
        if (loeweTigerNummer <= 8)
        {
            StartCoroutine(loewenTigerSpawnen(loeweTigerNummer - 1));
            StartCoroutine(loewenTigerSpawnen(loeweTigerNummer - 2));
            // HIER NÄCHSTE WELLE STARTEN (LETZTE)
        }
        else if (loeweTigerNummer > 8)
        {
            StartCoroutine(loewenTigerSpawnen(loeweTigerNummer - 1));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "spieler")
        {
            sklavenSpawnenAufruf();
            Debug.Log("Trigger aktiviert");
            Destroy(gameObject);
        }
    }
}
