﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FeindLebenTrex : MonoBehaviour {

    public float enemyMaxHealth;
    // public GameObject enemyDeathFX;
    Animator anim;
    public Slider enemySlider;
    public Transform pos;
    public GameObject blut;
    float currentHealth;
    public float timeBtwDamage;
   public  bool isDead;
    //  private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        currentHealth = enemyMaxHealth;
       enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;
            anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 25)
        {
            anim.SetTrigger("stateTwo");
        }

        if (currentHealth <= 0)
        {
            anim.SetBool("Death", true);
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }

      //  enemySlider.value = currentHealth;

    }


    public void addDamage(float damage)
    {

        enemySlider.gameObject.SetActive(true);
        SoundManagerScript.PlaySound("messer");
        currentHealth -= damage;

        Debug.Log("damage Taken");
        Instantiate(blut, transform.position, transform.rotation);
        enemySlider.value = currentHealth;
        if (currentHealth <= 0) makeDead();
    }

    void makeDead()
    {

        //   enemyAnimator.SetBool("isDead", true);

        Destroy(gameObject);
        // Instantiate(enemyDeathFX, transform.position, transform.rotation);
    }
}