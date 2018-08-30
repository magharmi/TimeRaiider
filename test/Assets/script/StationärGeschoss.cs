using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationärGeschoss : MonoBehaviour
{

    //spawn finden
    public Transform bulletspawn;
    public Rigidbody2D bulletPrefab;
    Rigidbody2D clone;
    public float bulletSpeed = 300f;
    public Transform player;
    public int schussGeschwindigkeit;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(schussGeschwindigkeit);
        if (bulletspawn.position.x > player.position.x)
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
