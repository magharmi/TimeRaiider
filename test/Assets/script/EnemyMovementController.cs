﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    public float enemySpeed;

    private Animator myAnimator;

    public GameObject enemyGraphic;

    //Facing
    bool canFlip = true;
    bool facingRight =false;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    //Attack
    public float chargeTime;
    float startChargeTime;
    public static bool  charging;
    public static bool  isAttacking = false;
    Rigidbody2D enemyRB;
  

    // Use this for initialization
    void Start() {
        myAnimator = GetComponentInChildren<Animator>();
        enemyRB    = GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Shootable"));
    }


    // Update is called once per frame
    void Update() {

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
            if (facingRight && other.transform.position.x < transform.position.x) {
                flipFacing();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x) {

                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime;
         
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "spieler") {
           
                if (!facingRight) enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);

                else enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
           
                myAnimator.SetBool("isRun", charging);
           
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "spieler")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            myAnimator.SetBool("isRun", charging);
           
        }
    }
   
    void flipFacing()
   {
        if (!canFlip) return;
        float facingX; 
        facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y,enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;
    }

    void RestartValues()
    {
        charging = false;
        isAttacking = false;
    }
}
