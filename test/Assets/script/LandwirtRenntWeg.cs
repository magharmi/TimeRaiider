using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandwirtRenntWeg : MonoBehaviour
{
    public SpriteRenderer sr;
    public Transform player;

    private float speed = 12;
    private float radius = 20;
    private Vector2 newPos;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("spieler").transform;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= radius)
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(newPos.x, transform.position.y), speed * Time.deltaTime);
            sr.flipX = true;
            newPos.x = transform.position.x + 10;
        }
        else
            Destroy(gameObject);
    }
}
