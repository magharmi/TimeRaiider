using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ziel : MonoBehaviour
{
    public string level;
    public int LevelToUnlock;
    private static int moneyAmount;
    private Slider sl;
    private Text levelAnzeige;
    private Text moneyText;

    private GameControlScript spielerWerte;

    private void Start()
    {
        spielerWerte = GameObject.Find("lvlmanager").GetComponent<GameControlScript>();
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spieler")
        {
            Debug.Log("ziel erreicht");
            PlayerPrefs.SetInt("levelReached", LevelToUnlock);
            PlayerPrefs.SetString("letzteScene", level);
            PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
            PlayerPrefs.SetFloat("EPValue", spielerWerte.sl.value);
            PlayerPrefs.SetInt("SpielerLevel", int.Parse(spielerWerte.levelAnzeige.text));
            SceneManager.LoadScene(level);
        }
    }
}
