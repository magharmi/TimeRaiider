using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
    GameControlScript sl;
    public float enemyMaxHealth;
    public bool drops;
    public bool gibtEp = true;
    public int ep = 10;
    public GameObject lebenOderGeld;
    public static  float epp;
    int gibLeben = 50;
    
    // public GameObject enemyDeathFX;
    //Animator enemyAnimator;
      public Slider enemySlider;
   // public Transform pos;
    //public GameObject blut;
   public float currentHealth;

	// Use this for initialization
	void Start () {
        sl = GameObject.Find("lvlmanager").GetComponent<GameControlScript>();
      //  enemyAnimator = GetComponentInChildren<Animator>();
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;
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
        if (drops)
            Instantiate(lebenOderGeld, transform.position, transform.rotation);
        if (gibtEp)
        {
            sl.addEP(ep);
            Debug.Log("Ep hinzugefügt");
        }
       
    }
   
}
