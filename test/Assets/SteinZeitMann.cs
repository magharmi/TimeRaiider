using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteinZeitMann : MonoBehaviour {
    float dirX;
    [SerializeField]
    float speed;
    Rigidbody2D rb;
    bool facingRight = false;

    Vector3 localScale;
    Animator myAnim;
    public static bool isAttacking = false;
	// Use this for initialization
	void Start () {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -9f)
            dirX = 1f;
        else if (transform.position.x > 9f)
            dirX = -1f;
        if (isAttacking)
            myAnim.SetBool("isAttack", true);
       
        else
            myAnim.SetBool("isAttack", false);
    
	}
    void FixedUpdate()
    {
        if (!isAttacking)
            rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;

        myAnim.SetBool("isRun", true);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }


    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }

}
