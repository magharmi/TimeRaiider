using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrohneSchiesst : MonoBehaviour
{

    //spawn finden
    public Transform bulletspawn;
    public Rigidbody2D bulletPrefab;
    public float bulletSpeed = 750;
    public float schussGeschwindigkeit;
    public float radius = 20;

    private Transform player;
    private Rigidbody2D clone;
    private bool geschossen;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("spieler").GetComponent<Transform>();
    }

    private void Update()
    {
        while (geschossen == false)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        geschossen = true;
        yield return new WaitForSeconds(schussGeschwindigkeit);
        if (Vector3.Distance(player.transform.position, bulletspawn.transform.position) < radius)
        {

            Vector3 difference = player.position - bulletspawn.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            bulletspawn.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

            clone = Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);

            clone.AddForce(bulletspawn.transform.right * bulletSpeed);
        }
        geschossen = false;
    }
}
