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

    private Vector2 startPos;
    private Vector2 newPos;
    private Vector2 tempPos;
    private PolygonCollider2D pg;
    private bool imRadius = true;
    
    public Transform player;
    //Hasan 8.1.2019
    Animator enemyAnimator;
    bool isFacingRight;
    //Hasan ENDE

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("spieler").transform;
        Lvlmanager = FindObjectOfType<lvlmanager>();
        startPos = transform.position;
        newPos = startPos;
        pg = gameObject.GetComponent<PolygonCollider2D>();

        //Hasan 8.1.2019
        enemyAnimator = GetComponent<Animator>();
        //Hasan ENDE
    }

    // Update is called once per frame
    void Update() {
        if (Vector2.Distance(transform.position, player.position) > radius) {
            newPos = startPos;
            if (imRadius == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
                if(Vector2.Distance(transform.position, newPos) == 0)
                {
                    imRadius = true;
                
                }
            }
            else
            {
                
                newPos.x = newPos.x + Mathf.PingPong(Time.time * speed, weg) - 3;
               
                transform.position = newPos;
         

                //Bewegung positiv
                if ( newPos.x > tempPos.x)
                {
                  
                    transform.rotation = Quaternion.Euler(0, 180f, 0);
                    //Hasan 8.1.2019
                   // enemyAnimator.SetBool("isRun", true);
                    //ENDE

                }
                //Bewegung negativ
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
               
                }
              
                tempPos = newPos;
            }
        }

        else if (Vector2.Distance(transform.position, player.position) <= radius)
        {
            imRadius = false;
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
             
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
         

            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                Vector2 ziel = new Vector2(player.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, ziel, -speed * Time.deltaTime);
              
                if (transform.position.x < ziel.x)
                {
                 
                    transform.rotation = Quaternion.Euler(0, 180f, 0);
                    
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    
                }
            }

        }
        //startPos = transform.position;        Raptor wird zu Usain Bolt, wenn ich diesen Code einfüge
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "spieler" && hit == true)
        {

            //Hasan 8.1.2019
           // enemyAnimator.SetBool("isAttack", true);
           //ENDE
            
            GameObject.FindGameObjectWithTag("spieler").GetComponent<Spieler_Leben>().addDamage(20);
            //Lvlmanager.RespawnSpieler();
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

    protected void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
