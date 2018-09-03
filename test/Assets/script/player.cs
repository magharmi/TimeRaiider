using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField]
    private Stats leben;
    


    private static int close;
    private int counter = 0;
    public Text scoretxt;
    public Text highscoretxt;
    public GameObject fakel,stoneAgeKnife;
    Inventory inventory;


    /*Stein Werfen
    public Transform  steinTip;
    public GameObject steinR,steinL;
    private float wurfRate = 0.5f;
    private float nextWurf = 0f;
   */

    // Use this for initialization
    void Start()
    {
     
        //  Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Spieler"), LayerMask.NameToLayer("Enemy"));
        leben.Initialize();
        fakel.SetActive(false);
     
        stoneAgeKnife.SetActive(false);

        counter = 0;
        //lade den highscore
        highscoretxt.text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();
        // anim = GetComponent<Animator>()
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //Feuer An
        if (Input.GetKey(KeyCode.F))
        {
            fakel.SetActive(true);
        }
        else
        {
            fakel.SetActive(false);
        }
        if (Input.GetKey(KeyCode.T))
        {
            stoneAgeKnife.SetActive(true);
        }
        else
        {
            stoneAgeKnife.SetActive(false);
        }
        /* 
         if (Input.GetKeyDown(KeyCode.Q))
         {
             leben.CurrentVal -= 10;
         }
         if (Input.GetKeyDown(KeyCode.T))
         {
             leben.CurrentVal += 10;
         }
         */
        /*SteinWerfen Left maus button if (Input.GetAxisRaw("Fire1")>0)(fireRocket();
        if (Input.GetKeyDown(KeyCode.R))
        {
         //   steineWerfen();
        }*/
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coin")
        {
            //grafik deaktivieren
            other.gameObject.GetComponent<Renderer>().enabled = false;
            //collider deaktivieren
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            //coin sound
            AudioSource audio = other.gameObject.GetComponent<AudioSource>();
            audio.Play();

            Destroy(other.gameObject, audio.clip.length);
            counter++;
            Debug.Log("coin gesammelt");
            scoretxt.text = counter.ToString();

            if (counter > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", counter);
                highscoretxt.text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();

            }

        }
    }
}
       

