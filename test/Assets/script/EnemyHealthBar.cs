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
    public static float epp;
    public int special = 0;
    int gibLeben = 50;

    //Fuer Feldherr
    private GameObject MainCamera, BosskampfKamera, BosskampfWandRechts;

    //Fuer Anubis
    public GameObject zielItem, kampfKamera, mainCamera, unsichtbareWand;

    public Slider enemySlider;
    public float currentHealth;

    //Use this for initialization
    void Start()
    {
        sl = GameObject.Find("lvlmanager").GetComponent<GameControlScript>();
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;

        if (special == 1) //Feldherr
        {
            MainCamera = GameObject.Find("Main Camera");
            BosskampfKamera = GameObject.Find("Bosskampf Kamera");
            BosskampfWandRechts = GameObject.Find("Bosskampf Wand rechts");
        }
        else if (special == 2) //Anubis
        {
            kampfKamera = GameObject.Find("Kampf Kamera");
            mainCamera = GameObject.Find("Main Camera");
            unsichtbareWand = GameObject.Find("Ende Arena");
        }
    }

    public void addDamage(float damage)
    {
        enemySlider.gameObject.SetActive(true);
        currentHealth -= damage;
        Debug.Log("dagage Taken");
        enemySlider.value = currentHealth;
        if (currentHealth <= 0) makeDead();
    }

    void makeDead()
    {
        if (special == 1) //Feldherr
        {
            MainCamera.SetActive(true);
            Destroy(BosskampfKamera);
            Destroy(BosskampfWandRechts);
        }
        if (special == 2) //Anubis
        {
            zielItem.GetComponent<SpriteRenderer>().enabled = true;
            kampfKamera.GetComponent<Camera>().enabled = false;
            mainCamera.GetComponent<Camera>().enabled = true;
            unsichtbareWand.SetActive(false);
        }

        //enemyAnimator.SetBool("isDead", true);
        Destroy(gameObject);

        //Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops)
            Instantiate(lebenOderGeld, transform.position, transform.rotation);
        if (gibtEp)
        {
            sl.addEP(ep);
            Debug.Log("Ep hinzugefügt");
        }
    }
   
}
