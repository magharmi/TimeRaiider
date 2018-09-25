using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerAI : MonoBehaviour {
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float radius;
    public lvlmanager Lvlmanager;
    public bool hit = true;
    public float weg = 6;
    public int leben = 100;
    public Vector3 startPos;
    public Vector3 newPos;
    public Vector3 tempPos;
    public SpriteRenderer sr;

    public Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("spieler").transform;
        Lvlmanager = FindObjectOfType<lvlmanager>();
        startPos = transform.position;
        newPos = startPos;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (Vector2.Distance(transform.position, player.position) > radius) {
            newPos = startPos;
            newPos.x = newPos.x + Mathf.PingPong(Time.time * speed, weg) - 3;

            transform.position = newPos;

            //Bewegung positiv
            if (newPos.x > tempPos.x)
            {
                sr.flipX = true;
            }
            //Bewegung negativ
            else
            {
                sr.flipX = false;
            }

            tempPos = newPos;
        }

        else if (Vector2.Distance(transform.position, player.position) <= radius)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
        }
        //startPos = transform.position;        Raptor wird zu Usain Bolt, wenn ich diesen Code einfüge
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "spieler" && hit == true)
        {
            Lvlmanager.RespawnSpieler();
            Debug.Log("geht nicht mehr");
            hit = false;
            StartCoroutine(FreezePlayer());
        }


        if (other.gameObject.tag == "bullet")
        {
            leben -= 10;
            if (leben == 0)
            {
                Destroy(gameObject, 0.2f);
            }
            //Destroy(gameObject, 0.2f);
            Destroy(other.gameObject, 0f);
        }
    }

    IEnumerator FreezePlayer()
    {
        //kann so lange kein schade vom gleichen gegner bekommen
        //wenn hit im managerscript, dann kann man ganz unverwundbar sein
        yield return new WaitForSeconds(1);
        hit = true;
        Debug.Log("geht wieder");
    }
}
