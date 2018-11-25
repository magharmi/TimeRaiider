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
    public SpriteRenderer sr;

    private bool isTriggered = false;
    private bool absturzSet = false;
    private Vector3 absturzPunkt;
    private Transform drohnenPosition;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("spieler").transform;
        Lvlmanager = FindObjectOfType<lvlmanager>();
        startPos = transform.position;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered == false)
        {
            if (Vector2.Distance(drohne.transform.position, player.position) <= radius)
            {
                schiessen();
                gameObject.GetComponent<Gegner>().enabled = false;
                /*if (Vector2.Distance(transform.position, absturzPunkt) == 0)
                {
                    Destroy(gameObject);
                }*/
            }
        }
    }

    void schiessen()
    {
        if (absturzSet == false)
        {
            absturzPunkt = player.position;
            absturzSet = true;
        }
        transform.position = Vector2.MoveTowards(transform.position, absturzPunkt, bulletspeed * Time.deltaTime);
    }

    void OnCollisionEnter2D()
    {
        Debug.Log("tot");
        Destroy(gameObject);
    }
}
