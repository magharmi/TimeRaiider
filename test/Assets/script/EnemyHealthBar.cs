using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
    public float enemyMaxHealth;
    // public GameObject enemyDeathFX;
    //Animator enemyAnimator;
      public Slider enemySlider;
   // public Transform pos;
    //public GameObject blut;
    float currentHealth;

	// Use this for initialization
	void Start () {
      //  enemyAnimator = GetComponentInChildren<Animator>();
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
      
	}


    public void addDamage(float damage)
    {
        enemySlider.gameObject.SetActive(true);
       // SoundManagerScript.PlaySound("messer");
        currentHealth -= damage;
        Debug.Log("dagage Taken");
       // Instantiate(blut, transform.position, transform.rotation);
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
