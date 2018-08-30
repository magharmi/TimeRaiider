using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    private static int close;
    private int counter = 0;
    public Text scoretxt;
    public Text highscoretxt;
    public GameObject fakel;
    Inventory inventory;
    // Use this for initialization
    void Start()
    {
        fakel.SetActive(false);
        counter = 0;
        //lade den highscore
        highscoretxt.text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
            {
                fakel.SetActive(true);
           
            }
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
       

