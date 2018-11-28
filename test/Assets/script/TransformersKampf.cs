using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformersKampf : MonoBehaviour
{

    public GameObject zielItem;

    private GameObject transformers, kampfKamera, mainCamera, unsichtbareWand;
    private Vector3 startPosition;
    private bool transformersZurück = false;
    private bool drohnenSpawnen = false;
    private bool leben350 = true;
    private bool leben200 = false;
    private bool leben0 = false;
    private GameObject[] drohnen;

    // Use this for initialization
    void Start()
    {
        transformers = GameObject.FindGameObjectWithTag("Boss");
        drohnen = GameObject.FindGameObjectsWithTag("AnubisMumien");
        kampfKamera = GameObject.Find("Kampf Kamera");
        mainCamera = GameObject.Find("Main Camera");
        startPosition = transformers.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (leben350 == true)
        {
            if (transformers.GetComponent<GegnerAI>().leben == 350)
            {
                if (transformersZurück == false)
                {
                    transformers.GetComponent<BoxCollider2D>().enabled = false;
                    transformers.GetComponent<GegnerAI>().speed = 0;
                    transformers.transform.position = Vector2.MoveTowards(transformers.transform.position, startPosition, 7 * Time.deltaTime);
                    if (transformers.transform.position == startPosition)
                    {
                        Debug.Log("Transformers zurück");
                        transformersZurück = true;
                        drohnenSpawnen = true;
                        transformers.GetComponent<GegnerAI>().leben = 350;
                    }
                }
                else if (drohnenSpawnen == true)
                {
                    drohnenSpawnenAufruf();
                    Debug.Log("Drohnen spawnen");
                    drohnenSpawnen = false;
                    leben350 = false;
                    leben200 = true;
                }
            }
        }
        else if (leben200 == true)
        {
            if (transformers.GetComponent<GegnerAI>().leben == 200)
            {
                if (transformersZurück == false)
                {
                    transformers.GetComponent<BoxCollider2D>().enabled = false;
                    transformers.GetComponent<GegnerAI>().speed = 0;
                    transformers.transform.position = Vector2.MoveTowards(transformers.transform.position, startPosition, 7 * Time.deltaTime);
                    if (transformers.transform.position == startPosition)
                    {
                        Debug.Log("Transformers zurück");
                        transformersZurück = true;
                        drohnenSpawnen = true;
                        transformers.GetComponent<GegnerAI>().leben = 200;
                    }
                }
                else if (drohnenSpawnen == true)
                {
                    drohnenSpawnenAufruf2();
                    Debug.Log("Drohnen spawnen");
                    drohnenSpawnen = false;
                    leben200 = false;
                    leben0 = true;
                }
            }
        }
        else if (leben0 == true)
        {
            if (transformers.GetComponent<GegnerAI>().leben == 0)
            {
                zielItem.GetComponent<SpriteRenderer>().enabled = true;
                kampfKamera.GetComponent<Camera>().enabled = false;
                mainCamera.GetComponent<Camera>().enabled = true;
                unsichtbareWand.SetActive(false);
                leben0 = false;
            }
        }
    }

    public void TransformersAngriff()
    {
        transformersZurück = false;
        transformers.GetComponent<BoxCollider2D>().enabled = true;
        transformers.GetComponent<GegnerAI>().speed = 5;
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
            TransformersAngriff();
        }
    }

    public void drohnenSpawnenAufruf2()
    {
        StartCoroutine(drohnenSpawnenFunc2(drohnen.Length - 1));
    }

    IEnumerator drohnenSpawnenFunc2(int drohnenNummer)
    {
        yield return new WaitForSeconds(2);
        if (drohnenNummer <= 8)
        {
            StartCoroutine(drohnenSpawnenFunc2(drohnenNummer - 1));
            StartCoroutine(drohnenSpawnenFunc2(drohnenNummer - 2));
            TransformersAngriff();
        }
        else if (drohnenNummer > 8)
        {
            StartCoroutine(drohnenSpawnenFunc2(drohnenNummer - 1));
        }
    }
}
