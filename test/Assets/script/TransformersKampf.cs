﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformersKampf : MonoBehaviour
{

    public GameObject zielItem;

    private GameObject transformers, spieler, russe;
    private Vector3 startPosition;
    private bool leben200 = false;
    private bool hochGeflogen = true;
    private bool inMitte = true;
    private bool beiSpieler = true;
    private GameObject[] drohnen;
    private Vector3 hochflugZiel, spielerPosition;

    // Use this for initialization
    void Start()
    {
        transformers = GameObject.FindGameObjectWithTag("Boss");
        drohnen = GameObject.FindGameObjectsWithTag("AnubisMumien");
        startPosition = transformers.transform.position;
        spieler = GameObject.FindGameObjectWithTag("spieler");
        russe = GameObject.Find("Russe");
    }

    // Update is called once per frame
    void Update()
    {

        if (transformers.GetComponent<GegnerAI>().leben == 350)
        {
            Debug.Log("Beine kaputt");
            hochGeflogen = true;
            inMitte = true;
            beiSpieler = true;
            if (Vector3.Distance(transformers.transform.position, startPosition) != 0)
            {
                Debug.Log("Fliege zurück");
                transformers.transform.position = Vector2.MoveTowards(transformers.transform.position, startPosition, 7 * Time.deltaTime);
            }
            else
            {
                drohnenSpawnenAufruf();
                Debug.Log("Drohnen spawnen");
            }
        }

        else if (leben200 == true)
        {
            Debug.Log("Russe kommt");
            transformers.GetComponent<BoxCollider2D>().enabled = false;
            russe.GetComponent<SpriteRenderer>().enabled = true;
            russe.GetComponent<GegnerAI>().enabled = true;
            russe.GetComponent<BoxCollider2D>().enabled = true;
            leben200 = false;
        }


        else if (russe.GetComponent<GegnerAI>().leben <= 0)
        {
            russe.GetComponent<GegnerAI>().enabled = false;
            GameObject.Find("RusseEnde").GetComponent<BoxCollider2D>().enabled = true;
        }

        if (hochGeflogen == false)
        {
            Debug.Log("FLIEG");
            transformers.transform.position = Vector3.MoveTowards(transformers.transform.position, hochflugZiel, 10 * Time.deltaTime);
            if (Vector3.Distance(transformers.transform.position, hochflugZiel) == 0)
            {
                hochGeflogen = true;
                Debug.Log("Oben angekommen");
                inMitte = false;
            }
        }
        if (inMitte == false)
        {
            transformers.transform.position = Vector3.MoveTowards(transformers.transform.position, new Vector3(115, transformers.transform.position.y, transformers.transform.position.z), 10 * Time.deltaTime);
            if (Vector3.Distance(transformers.transform.position, new Vector3(115, transformers.transform.position.y, transformers.transform.position.z)) == 0)
            {
                inMitte = true;
                Debug.Log("In Mitte angekommen");
                StartCoroutine(warteSekundenDannSpielerAngriff(3));
            }
        }
        if (beiSpieler == false)
        {
            transformers.transform.position = Vector3.MoveTowards(transformers.transform.position, spielerPosition, 15 * Time.deltaTime);
            if (Vector3.Distance(transformers.transform.position, spielerPosition) == 0)
            {
                beiSpieler = true;
                Debug.Log("Bei Spieler angekommen");
                StartCoroutine(warteSekundenDannHoch(3));
            }
        }
    }

    public void TransformersAngriff()
    {
        Debug.Log("Start");
        transformers.GetComponent<BoxCollider2D>().enabled = true;
        flugzielSetzen();
        hochGeflogen = false;
    }

    public void TransformersLaserSchiessen()
    {

    }

    public void drohnenSpawnenAufruf()
    {
        StartCoroutine(drohnenSpawnenFunc(drohnen.Length - 1));
    }

    IEnumerator drohnenSpawnenFunc(int drohnenNummer)
    {
        drohnen[drohnenNummer].GetComponent<SpriteRenderer>().enabled = true;
        drohnen[drohnenNummer].GetComponent<GegnerAI>().enabled = true;
        yield return new WaitForSeconds(2);
        if (drohnenNummer <= 8)
        {
            StartCoroutine(drohnenSpawnenFunc(drohnenNummer - 1));
            StartCoroutine(drohnenSpawnenFunc(drohnenNummer - 2));
        }
        else if (drohnenNummer > 8)
        {
            StartCoroutine(drohnenSpawnenFunc(drohnenNummer - 1));
        }
        if (drohnenNummer == 0)
        {
            yield return new WaitForSeconds(5);
            leben200 = true;
        }
    }

    private void flugzielSetzen()
    {
        hochflugZiel = new Vector3(transformers.transform.position.x, transformers.transform.position.y + 12, 0.0f);
    }

    private void spielerPositionSetzen()
    {
        spielerPosition = new Vector3(spieler.transform.position.x, (float)-51.5, spieler.transform.position.z);
    }

    IEnumerator warteSekundenDannSpielerAngriff(float sekunden)
    {
        yield return new WaitForSeconds(sekunden);
        spielerPositionSetzen();
        beiSpieler = false;
    }

    IEnumerator warteSekundenDannHoch(float sekunden)
    {
        yield return new WaitForSeconds(sekunden);
        hochGeflogen = false;
        Debug.Log("wieder hoch");
    }

}