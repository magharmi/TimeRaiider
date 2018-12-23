using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{

    public float speed;
    public float radius;
    public Vector3 startPos;
    public lvlmanager Lvlmanager;
    public Transform player;
    public SpriteRenderer sr;

    private bool isTriggered = false;
    private bool absturzSet = false;
    private Vector3 absturzPunkt;

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
            if (Vector2.Distance(transform.position, player.position) <= radius)
            {
                isTriggered = true;
            }
        }
        else
        {
            KamikazeAngriff();
        }
        if (Vector2.Distance(transform.position, absturzPunkt) == 0)
        {
            Destroy(gameObject);
        }

    }

    void KamikazeAngriff()
    {
        gameObject.GetComponent<GegnerAI>().enabled = false;
        if (absturzSet == false)
        {
            absturzPunkt = player.position;
            absturzSet = true;
        }
        transform.position = Vector2.MoveTowards(transform.position, absturzPunkt, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, 30);
    }

    void OnCollisionEnter2D()
    {
        Debug.Log("tot");
        Destroy(gameObject);
    }
}
