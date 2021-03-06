﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrontoControll : MonoBehaviour
{

    public float enemySpeed;

    Animator enemyAnimator;

    //facing
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 3f;
    float nextFlipChance = 0f;



    Vector3 localScale;

    public static bool isAttacking = false;
    //attack
    public float chargeTime;
    float startChargeTime;
    bool charging, isAttack;
    Rigidbody2D enemyRB;
    //bool isAttack;

    // Use this for initialization
    void Start()
    {
        
        localScale = transform.localScale;

        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

        if (Time.time < nextFlipChance)
        {
            if (Random.Range(0, 10) >= 5) flipFacing();
            nextFlipChance = Time.time + flipTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spieler")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {

                flipFacing();
            }
            canFlip = false;

            charging = true;
            startChargeTime = Time.time + chargeTime;

        }
   
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "spieler")
        {
            if (startChargeTime < Time.time)
            {
                if (!facingRight) enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);

                else enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
          
                    enemyAnimator.SetBool("isRun", charging);


                    isAttack = true;
                    enemyAnimator.SetBool("isRun", isAttack);
                
              

            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "spieler")
        {
            canFlip = true;
            charging = false;
            isAttack = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            if(gameObject!=null)
            enemyAnimator.SetBool("isRun", charging);
           enemyAnimator.SetBool("isAttack", isAttack);
        }
    }


    void flipFacing()
    {


        if (!canFlip) return;

        float facingX;
        facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);

        facingRight = !facingRight;

    }
}