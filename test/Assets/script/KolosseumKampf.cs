using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolosseumKampf : MonoBehaviour
{
    public GameObject zielItem;

    private GameObject champion, kampfKamera, mainCamera, unsichtbareWand;
    private GameObject[] sklaven, loewenTiger;
    private BoxCollider2D[] myColliders;

    // Use this for initialization
    void Start()
    {
        champion = GameObject.FindGameObjectWithTag("Boss");
        sklaven = GameObject.FindGameObjectsWithTag("AnubisMumien");
        loewenTiger = GameObject.FindGameObjectsWithTag("AnubisMumien2");
        kampfKamera = GameObject.Find("Kampf Kamera");
        mainCamera = GameObject.Find("Main Camera");
        champion.GetComponent<EnemyHealthBar>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        /* wird jetzt in EnemyHealthBar gehandled
        if(champion.GetComponent<EnemyHealthBar>().currentHealth <= 55)
        {
            zielItem.GetComponent<SpriteRenderer>().enabled = true;
            zielItem.GetComponent<PolygonCollider2D>().enabled = true;
        }*/
    }

    public void sklavenSpawnenAufruf()
    {
        StartCoroutine(sklavenSpawnenFunc(sklaven.Length - 1));
    }

    IEnumerator sklavenSpawnenFunc(int sklavenNummer)
    {
        sklaven[sklavenNummer].GetComponent<SpriteRenderer>().enabled = true;
        sklaven[sklavenNummer].transform.GetChild(0).GetComponent<Canvas>().enabled = true;
        myColliders = sklaven[sklavenNummer].GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = true;
        sklaven[sklavenNummer].GetComponent<GegnerAI>().radius = 100;
        sklaven[sklavenNummer].GetComponent<EnemyHealthBar>().enabled = true;
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
            Debug.Log("Alle Tot aus erster Welle");
            yield return new WaitForSeconds(5);
            loewenTigerSpawnenAufruf();
        }
    }

    public void loewenTigerSpawnenAufruf()
    {
        StartCoroutine(loewenTigerSpawnen(loewenTiger.Length - 1));
    }

    IEnumerator loewenTigerSpawnen(int loewenTigerNummer)
    {
        loewenTiger[loewenTigerNummer].GetComponent<SpriteRenderer>().enabled = true;
        loewenTiger[loewenTigerNummer].transform.GetChild(0).GetComponent<Canvas>().enabled = true;
        myColliders = loewenTiger[loewenTigerNummer].GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = true;
        loewenTiger[loewenTigerNummer].GetComponent<GegnerAI>().radius = 100;
        loewenTiger[loewenTigerNummer].GetComponent<EnemyHealthBar>().enabled = true;
        yield return new WaitForSeconds(2);
        if (loewenTigerNummer <= 8)
        {
            StartCoroutine(loewenTigerSpawnen(loewenTigerNummer - 1));
            StartCoroutine(loewenTigerSpawnen(loewenTigerNummer - 2));
        }
        else if (loewenTigerNummer > 8)
        {
            StartCoroutine(loewenTigerSpawnen(loewenTigerNummer - 1));
        }
        if (loewenTigerNummer == 0)
        {
            Debug.Log("Alle Tot aus zweiter Welle");
            yield return new WaitForSeconds(5);
            championSpawnen();
        }
    }

    void championSpawnen()
    {
        champion.GetComponent<SpriteRenderer>().enabled = true;
        champion.GetComponent<EnemyHealthBar>().enabled = true;
        champion.GetComponent<GegnerAI>().radius = 100;
        myColliders = champion.GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = true;
        champion.GetComponent<GegnerAI>().enabled = true;
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
