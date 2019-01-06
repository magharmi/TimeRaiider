using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationärGeschoss : MonoBehaviour
{

    //spawn finden
    public Transform bulletspawn;
    public Rigidbody2D bulletPrefab;
    public float bulletSpeed = 300f;
    public float schussGeschwindigkeit;
    public char richtung;

    
    private Rigidbody2D clone;

    // Use this for initialization
    void Start()
    {
       // player = GameObject.FindGameObjectWithTag("spieler").GetComponent<Transform>();
        StartCoroutine(Attack());
    }



    IEnumerator Attack()
    {
        yield return new WaitForSeconds(schussGeschwindigkeit);
        if (richtung=='r')
        {
            clone = Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);
            //rechts werfen
            clone.AddForce(bulletspawn.transform.right * bulletSpeed);
            StartCoroutine(Attack());
        }
        else
        {
            //Links werfen
            clone = Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);
            clone.AddForce(bulletspawn.transform.right * -bulletSpeed);
            StartCoroutine(Attack());

        }
    }
}
