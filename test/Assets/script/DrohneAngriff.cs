using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrohneAngriff : MonoBehaviour
{
    public GameObject drohne;
    public float bulletspeed;
    public float radius;
    public Vector3 startPos;
    public lvlmanager Lvlmanager;
    public Transform player;
    public float zeitBisSchuss;

    private bool absturzSet = false;
    private Vector3 absturzPunkt;
    private bool bulletVerfügbar = true;
    private bool isTriggered = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("spieler").transform;
        Lvlmanager = FindObjectOfType<lvlmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered == false)
        {
            if (bulletVerfügbar == true)
                transform.position = drohne.transform.position;

            if (Vector2.Distance(transform.position, player.position) <= radius)
            {
                StartCoroutine(schiessen());
                isTriggered = true;
            }
        }
    }

    IEnumerator schiessen()
    {
        bulletVerfügbar = false;
        absturzPunkt = player.position;
        transform.position = Vector2.MoveTowards(transform.position, absturzPunkt, bulletspeed * Time.deltaTime);
        Debug.Log("Schuss");
        yield return new WaitForSeconds(zeitBisSchuss);
        bulletVerfügbar = true;
    }

    void OnCollisionEnter2D()
    {
        Debug.Log("tot");
        Destroy(gameObject);
    }
}
