using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZielItemNächsterAkt : MonoBehaviour {
    public string nächstesLevel;
    private static int moneyAmount;
    private Slider sl;
    private Text levelAnzeige;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "spieler")
        {
            PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
            PlayerPrefs.SetFloat("EPValue", sl.value);
            PlayerPrefs.SetInt("SpielerLevel", int.Parse(levelAnzeige.text));
            SceneManager.LoadScene(nächstesLevel);
        }
    }
}
