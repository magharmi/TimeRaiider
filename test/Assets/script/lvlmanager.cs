using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lvlmanager : MonoBehaviour
{

    //checkpoint
    public GameObject currentCheckpoint;
    public float leben;
    public GameObject spieler;
    public Text lebentxt;
    public GameObject GameOverUI;

    public Text timertxt;
    public float roundTimer;
    private DialogueManager dialogueManager;
    private bool gehitted = false;



    void Start()
    {
        lebentxt.text = " " + leben.ToString();
        leben = spieler.GetComponent<Spieler_Leben>().currentLeben;  //GAMEOVER GEHT DAMIT NICHT!
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //spiel beenden 
            Debug.Log("Spiel beenden");
            Application.Quit();
        }

        //vergangene zeit abziehen vom counter
        roundTimer = roundTimer - Time.deltaTime;

        timertxt.text = ((int)roundTimer).ToString();

        if (roundTimer <= 0f)
        {
            //zeit abgelaufen
            Debug.Log("zeit abgelaufen");
        }
    }


    public void RespawnSpieler()
    {

        //leben abziehen
        //leben = leben - 1;
        //lebensanzeige aktualisieren
        //lebentxt.text = "Leben: " + leben.ToString();
        //überprüfen ob spieler noch leben hat
        if (leben > 0)
        {
            spieler.transform.position = currentCheckpoint.transform.position;
        }
        else if (leben == 0)
        {
            Debug.Log("game over");
            //bild stop
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
            leben = -1;
            StartCoroutine(WarteAufEnter());
        }

        //nein -> spielende
    }

    IEnumerator WarteAufEnter()
    {
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void LebenErhöhen(int anzahl)
    {
        leben = leben + anzahl;
        lebentxt.text = "Leben: " + leben.ToString();
    }
}
