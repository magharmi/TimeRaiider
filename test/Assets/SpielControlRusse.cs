using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpielControlRusse : MonoBehaviour
{

    public Text moneyText;
    public static int moneyAmount;
    int isRifleSold;
    public GameObject rifle;

    // Use this for initialization
    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
        isRifleSold = PlayerPrefs.GetInt("IsRifleSold");

        if (isRifleSold == 1)
            rifle.SetActive(true);
        else
            rifle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + moneyAmount.ToString() + "$";
    }

    public void gotoShop()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        SceneManager.LoadScene("Stone_AgeBasar");
    }
}

