using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisKampf : MonoBehaviour {

    public GameObject zielItem;

    private GameObject anubis, kampfKamera, mainCamera, unsichtbareWand;
    private Vector3 startPosition;
    private bool anubisZurück = false;
    private bool mumienSpawnen = false;
    private bool leben350 = true;
    private bool leben200 = false;
    private bool leben0 = false;
    private GameObject[] mumien, mumien2, steine;
    private BoxCollider2D[] myColliders;

    // Use this for initialization
    void Start () {
        anubis = GameObject.FindGameObjectWithTag("Boss");
        mumien = GameObject.FindGameObjectsWithTag("AnubisMumien");
        mumien2 = GameObject.FindGameObjectsWithTag("AnubisMumien2");
        steine = GameObject.FindGameObjectsWithTag("AnubisSteine");
        kampfKamera = GameObject.Find("Kampf Kamera");
        mainCamera = GameObject.Find("Main Camera");
        unsichtbareWand = GameObject.Find("Ende Arena");
        startPosition = anubis.transform.position;
        myColliders = anubis.GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = false;
        anubis.GetComponent<GegnerAI>().speed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(leben350 == true)
        {
            if (anubis.GetComponent<EnemyHealthBar>().currentHealth == 350)
            {
                if (anubisZurück == false)
                {
                    myColliders = anubis.GetComponents<BoxCollider2D>();
                    foreach (BoxCollider2D bc in myColliders) bc.enabled = false;
                    anubis.GetComponent<GegnerAI>().speed = 0;
                    anubis.transform.position = Vector2.MoveTowards(anubis.transform.position, startPosition, 7 * Time.deltaTime);
                    if (anubis.transform.position == startPosition)
                    {
                        Debug.Log("Anubis zurück");
                        anubisZurück = true;
                        mumienSpawnen = true;
                        anubis.GetComponent<EnemyHealthBar>().currentHealth = 350;
                    }
                }
                else if (mumienSpawnen == true)
                {
                    mumienSpawnenAufruf();
                    Debug.Log("Mumien spawnen");
                    mumienSpawnen = false;
                    leben350 = false;
                    leben200 = true;
                }
            }
        }
        else if(leben200 == true)
        {
            if (anubis.GetComponent<EnemyHealthBar>().currentHealth== 200)
            {
                if (anubisZurück == false)
                {
                    myColliders = anubis.GetComponents<BoxCollider2D>();
                    foreach (BoxCollider2D bc in myColliders) bc.enabled = false;
                    anubis.GetComponent<GegnerAI>().speed = 0;
                    anubis.transform.position = Vector2.MoveTowards(anubis.transform.position, startPosition, 7 * Time.deltaTime);
                    if (anubis.transform.position == startPosition)
                    {
                        Debug.Log("Anubis zurück");
                        anubisZurück = true;
                        mumienSpawnen = true;
                        anubis.GetComponent<EnemyHealthBar>().currentHealth = 200;
                    }
                }
                else if (mumienSpawnen == true)
                {
                    mumienSpawnenAufruf2();
                    Debug.Log("Mumien spawnen");
                    mumienSpawnen = false;
                    leben200 = false;
                    leben0 = true;
                }
            }
        }
        else if(leben0 == true)
        {
            if (anubis.GetComponent<EnemyHealthBar>().currentHealth <= 20)
            {
                zielItem.GetComponent<SpriteRenderer>().enabled = true;
                kampfKamera.GetComponent<Camera>().enabled = false;
                mainCamera.GetComponent<Camera>().enabled = true;
                unsichtbareWand.SetActive(false);
                leben0 = false;
            }
        }
	}

    public void AnubisAngriff()
    {
        myColliders = anubis.GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = true;
        anubisZurück = false;
        anubis.GetComponent<GegnerAI>().speed = 5;
    }

    public void mumienSpawnenAufruf()
    {
        StartCoroutine(mumienSpawnenFunc(mumien.Length-1));
    }

    IEnumerator mumienSpawnenFunc(int mumienNummer)
    {
        mumien[mumienNummer].GetComponent<SpriteRenderer>().enabled = true;
        mumien[mumienNummer].GetComponent<BoxCollider2D>().enabled = true;
        mumien[mumienNummer].transform.GetChild(0).GetComponent<Canvas>().enabled = true;
        myColliders = mumien[mumienNummer].GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = true;
        mumien[mumienNummer].GetComponent<GegnerAI>().enabled = true;
        yield return new WaitForSeconds(2);
        if(mumienNummer <= 8)
        {
            StartCoroutine(mumienSpawnenFunc(mumienNummer - 1));
            StartCoroutine(mumienSpawnenFunc(mumienNummer - 2));
        }
        else if(mumienNummer > 8)
        {
            StartCoroutine(mumienSpawnenFunc(mumienNummer - 1));
        }
        if(mumienNummer == 0)
        {
            yield return new WaitForSeconds(5);
            AnubisAngriff();
        }
    }

    public void mumienSpawnenAufruf2()
    {
        StartCoroutine(mumienSpawnenFunc2(mumien.Length - 1, steine.Length - 1));
    }

    IEnumerator mumienSpawnenFunc2(int mumienNummer, int steinNummer)
    {
        mumien2[mumienNummer].GetComponent<SpriteRenderer>().enabled = true;
        mumien2[mumienNummer].GetComponent<BoxCollider2D>().enabled = true;
        myColliders = mumien2[mumienNummer].GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = true;
        mumien2[mumienNummer].transform.GetChild(0).GetComponent<Canvas>().enabled = true;
        mumien2[mumienNummer].GetComponent<GegnerAI>().enabled = true;
        steine[steinNummer].GetComponent<SpriteRenderer>().enabled = true;
        steine[steinNummer].GetComponent<PolygonCollider2D>().enabled = true;
        steine[steinNummer].GetComponent<Rigidbody2D>().isKinematic = false;
        StartCoroutine(steinZerstören(steinNummer));
        yield return new WaitForSeconds(2);
        if (mumienNummer <= 8)
        {
            StartCoroutine(mumienSpawnenFunc2(mumienNummer - 1, steinNummer - 1));
            StartCoroutine(mumienSpawnenFunc2(mumienNummer - 2, steinNummer - 2));
            AnubisAngriff();
        }
        else if (mumienNummer > 8)
        {
            StartCoroutine(mumienSpawnenFunc2(mumienNummer - 1, steinNummer - 1));
        }
    }

    IEnumerator steinZerstören(int steinNummer)
    {
        yield return new WaitForSeconds(5);
        Destroy(steine[steinNummer]);
    }
}
