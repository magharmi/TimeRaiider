using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaheimKampf : MonoBehaviour
{
    public GameObject zielItem;

    private GameObject champion, kampfKamera, mainCamera, unsichtbareWand;
    private GameObject[] agenten, raumschiffAgenten;

    // Use this for initialization
    void Start()
    {
        champion = GameObject.FindGameObjectWithTag("Boss");
        agenten = GameObject.FindGameObjectsWithTag("AnubisMumien");
        raumschiffAgenten = GameObject.FindGameObjectsWithTag("AnubisMumien2");
        kampfKamera = GameObject.Find("Kampf Kamera");
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (champion.GetComponent<GegnerAI>().leben == 0)
        {
            zielItem.GetComponent<SpriteRenderer>().enabled = true;
            zielItem.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

    public void agentenSpawnenAufruf()
    {
        StartCoroutine(agentenSpawnenFunc(agenten.Length - 1));
    }

    IEnumerator agentenSpawnenFunc(int agentenNummer)
    {
        agenten[agentenNummer].GetComponent<SpriteRenderer>().enabled = true;
        agenten[agentenNummer].GetComponent<GegnerAI>().enabled = true;
        yield return new WaitForSeconds(2);
        if (agentenNummer <= 8)
        {
            StartCoroutine(agentenSpawnenFunc(agentenNummer - 1));
            StartCoroutine(agentenSpawnenFunc(agentenNummer - 2));
        }
        else if (agentenNummer > 8)
        {
            StartCoroutine(agentenSpawnenFunc(agentenNummer - 1));
        }
        if (agentenNummer == 0)
        {
            Debug.Log("Alle Tot aus erster Welle");
            yield return new WaitForSeconds(5);
            raumschiffAgentenSpawnenAufruf();
        }
    }

    public void raumschiffAgentenSpawnenAufruf()
    {
        StartCoroutine(raumschiffAgentenSpawnen(raumschiffAgenten.Length - 1));
    }

    IEnumerator raumschiffAgentenSpawnen(int raumschiffAgentenNummer)
    {
        raumschiffAgenten[raumschiffAgentenNummer].GetComponent<SpriteRenderer>().enabled = true;
        raumschiffAgenten[raumschiffAgentenNummer].GetComponent<GegnerAI>().enabled = true;
        yield return new WaitForSeconds(2);
        if (raumschiffAgentenNummer <= 8)
        {
            StartCoroutine(raumschiffAgentenSpawnen(raumschiffAgentenNummer - 1));
            StartCoroutine(raumschiffAgentenSpawnen(raumschiffAgentenNummer - 2));
        }
        else if (raumschiffAgentenNummer > 8)
        {
            StartCoroutine(raumschiffAgentenSpawnen(raumschiffAgentenNummer - 1));
        }
        if (raumschiffAgentenNummer == 0)
        {
            Debug.Log("Alle Tot aus zweiter Welle");
            yield return new WaitForSeconds(5);
            championSpawnen();
        }
    }

    void championSpawnen()
    {
        champion.GetComponent<SpriteRenderer>().enabled = true;
        champion.GetComponent<GegnerAI>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "spieler")
        {
            agentenSpawnenAufruf();
            Debug.Log("Trigger aktiviert");
            Destroy(gameObject);
        }
    }
}
