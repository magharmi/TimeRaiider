using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
    [SerializeField]
    GameObject TextHit;
   
    public Slider enemySlider;
    public float enemyMaxHealth;
    float currentHealth;
    public bool drops;
    public GameObject theDrop;
    //public Transform pos;
   // public GameObject floatingTextPrefrap;


    //public GameObject enemyDeathFX;
    Animator anim;
    //private Animator anim;


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
        //für asing
        //if (floatingTextPrefrap )
      
        enemySlider.gameObject.SetActive(true);
        SoundManagerScript.PlaySound("messer");
      //  Instantiate(floatingTextPrefrap,new Vector3 (transform.position.x,transform.position.y+1.5f ,transform.position.z),Quaternion.identity);
        currentHealth -= damage;
        if (TextHit && currentHealth>0)
        {
            ShowFloatingText();
        }
        

        Debug.Log("damage Taken");
        //Instantiate(blut, transform.position, transform.rotation);

        enemySlider.value = currentHealth;
        if (currentHealth <= 0) makeDead();
    }

    void ShowFloatingText()
    {
        
        var go =Instantiate(TextHit, transform.position, transform.rotation);
        go.GetComponentInChildren<Text>().text = currentHealth.ToString();
    }
    void makeDead()
    {

        //   enemyAnimator.SetBool("isDead", true);
      
        Destroy(gameObject);
        Destroy(enemySlider.gameObject);
        // Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops) Instantiate(theDrop, transform.position, transform.rotation);
    }
   
}
