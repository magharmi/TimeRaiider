using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaheimKampf : MonoBehaviour
{
    public GameObject zielItem;

    private GameObject kampfKamera, mainCamera, unsichtbareWand, helikopter, beiZeitmaschine, grossvater, nächstesZiel;
    private GameObject[] agenten, raumschiffAgenten;
    private bool heliLandet;
    private BoxCollider2D[] myColliders;

    // Use this for initialization
    void Start()
    {
        agenten = GameObject.FindGameObjectsWithTag("AnubisMumien");
        raumschiffAgenten = GameObject.FindGameObjectsWithTag("AnubisMumien2");
        kampfKamera = GameObject.Find("Kampf Kamera");
        mainCamera = GameObject.Find("Main Camera");
        helikopter = GameObject.Find("Helikopter");
        beiZeitmaschine = GameObject.Find("Bei Zeitmaschine");
        grossvater = GameObject.Find("Grossvater");
        unsichtbareWand = GameObject.Find("Bei Opa");
        nächstesZiel = GameObject.Find("Ziel");
    }

    public void agentenSpawnenAufruf()
    {
        StartCoroutine(agentenSpawnenFunc(agenten.Length - 1));
    }

    IEnumerator agentenSpawnenFunc(int agentenNummer)
    {
        agenten[agentenNummer].GetComponent<SpriteRenderer>().enabled = true;
        agenten[agentenNummer].transform.GetChild(0).GetComponent<Canvas>().enabled = true;
        myColliders = agenten[agentenNummer].GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = true;
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
            if (heliLandet == false)
            {
                Debug.Log("Alle Tot aus erster Welle");
                beiZeitmaschine.SetActive(false);
                helikopter.GetComponent<Rigidbody2D>().isKinematic = false;
                yield return new WaitForSeconds(3);
                helikopter.GetComponent<Rigidbody2D>().isKinematic = true;
                heliLandet = true;
            }
            yield return new WaitForSeconds(2);
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
        raumschiffAgenten[raumschiffAgentenNummer].transform.GetChild(0).GetComponent<Canvas>().enabled = true;
        raumschiffAgenten[raumschiffAgentenNummer].GetComponent<GegnerAI>().enabled = true;
        myColliders = raumschiffAgenten[raumschiffAgentenNummer].GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = true;
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
            grossvater.GetComponent<BoxCollider2D>().enabled = true;
            grossvater.GetComponent<GegnerAI>().enabled = true;
            mainCamera.GetComponent<Camera>().enabled = true;
            kampfKamera.GetComponent<Camera>().enabled = false;
            Destroy(unsichtbareWand);
            nächstesZiel.GetComponent<BoxCollider2D>().enabled = true;

        }
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
