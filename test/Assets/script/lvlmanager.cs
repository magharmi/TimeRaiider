using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lvlmanager : MonoBehaviour
{

    //checkpoint
    public GameObject currentCheckpoint;
    private GameObject spieler;
    public GameObject GameOverUI;
    private DialogueManager dialogueManager;
    private bool gehitted = false;

    public void Start()
    {
        spieler = GameObject.FindGameObjectWithTag("spieler");
    }

    public void RespawnSpieler()
    {

        //leben abziehen
        //leben = leben - 1;
        //lebensanzeige aktualisieren
        //lebentxt.text = "Leben: " + leben.ToString();
        //überprüfen ob spieler noch leben hat
        if (spieler.GetComponent<Spieler_Leben>().currentLeben > 0)
        {
            spieler.transform.position = currentCheckpoint.transform.position;
        }
        else if (spieler.GetComponent<Spieler_Leben>().currentLeben <= 0)
        {
            Debug.Log("game over");
            //bild stop
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
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
        spieler.GetComponent<Spieler_Leben>().currentLeben = spieler.GetComponent<Spieler_Leben>().currentLeben + anzahl;
    }
}
