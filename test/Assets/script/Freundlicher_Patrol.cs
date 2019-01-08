using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freundlicher_Patrol : MonoBehaviour {
    public  float speed;
    private float  warteZeit;
    public float starteWarteZeit;
    bool isFacingRight;
    public Transform zielPunkt;
    private Transform zielPunkt2=zielPunkt;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private Animator anim;

	// Use this for initialization
	void Start () {
        warteZeit = starteWarteZeit;
        anim = GetComponent<Animator>();
        neuePosition(zielPunkt);
      
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, zielPunkt.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, zielPunkt.position) < 0.2f)
        {
            if (warteZeit <= 0)
            {
                if (zielPunkt > zielPunkt2)
                {
                    Flip();
                }
                anim.SetBool("isRun", true);
                zielPunkt.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                warteZeit = starteWarteZeit;
            }
            else
            {
                anim.SetBool("isRun", false);
                warteZeit -= Time.deltaTime;
            }
        }

        }

    protected void neuePosition(Transform zielpunkt)
    {
      
        zielpunkt.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

    }

    protected void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

      
    }
}

