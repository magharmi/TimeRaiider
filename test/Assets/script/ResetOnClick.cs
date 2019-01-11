using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetOnClick : MonoBehaviour {
    private bool sicher = false;
    private Text button;

    private void Start()
    {
        button = GameObject.Find("Neues Spiel").GetComponent<Button>().GetComponentInChildren<Text>();
    }


    public void resetGame()
    {
        if(sicher == false)
        {
            button.text = "Sicher?";
            sicher = true;
        }
        else
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("letzteScene", "null");
            sicher = false;
            button.text = "Neues Spiel";
            button.GetComponentInParent<Button>().interactable = false;
            Debug.Log("Spielstand gelöscht");
        }
    }
}