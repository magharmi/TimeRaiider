using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour {

    public float speed;
    public float radius;
    public Vector3 startPos;
    public lvlmanager Lvlmanager;
    public Transform player;
    public SpriteRenderer sr;

    private bool isTriggered = false;
    private Vector3 absturzPunkt;

    // Use this for initialization
    void Start () {
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
                KamikazeAngriff();
                if (Vector2.Distance(transform.position, absturzPunkt.position) == 0)
                {
                    isTriggered = true;
                }
            }
        }
    }

    void KamikazeAngriff()
    {
        absturzPunkt = player.position;
        transform.position = Vector2.MoveTowards(transform.position, absturzPunkt.position, speed * Time.deltaTime);
    }
}
