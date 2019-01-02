using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour {

    private Slider sl;
    private Text epAnzeige;
    private GameObject slider;
    private Text moneyText;
	public static int moneyAmount;
	int isRifleSold;
	public GameObject rifle;

	// Use this for initialization
	void Start () {
        slider = GameObject.Find("SliderEP");
        sl = GameObject.Find("Slider").GetComponent<Slider>();
        moneyText = GameObject.Find("GoldZaehler").GetComponent<Text>();
        epAnzeige = GameObject.Find("EP").GetComponent<Text>();


        //currentLevel = fullLevel;

        sl.maxValue = 100;
        sl.value    = 0;

        //currentLevel = fullLevel;


        moneyAmount = PlayerPrefs.GetInt ("MoneyAmount");
		isRifleSold = PlayerPrefs.GetInt ("IsRifleSold");
        sl.value = PlayerPrefs.GetFloat("EPValue");
        epAnzeige.text = PlayerPrefs.GetInt("SpielerLevel").ToString();

        

		if (isRifleSold == 1)
			rifle.SetActive (true);
		else
			rifle.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "Gold: " + moneyAmount.ToString() + "$";
	}

	public void gotoShop()
	{
		PlayerPrefs.SetInt ("MoneyAmount", moneyAmount);
        PlayerPrefs.SetFloat("EPValue", sl.value);
        PlayerPrefs.SetInt("SpielerLevel", int.Parse(epAnzeige.text));
		SceneManager.LoadScene ("ShopStoneAge");
	}

    public void addEP(float epAmount)
    {
        sl.value += epAmount;
        if (sl.value >= sl.maxValue)
        {
            sl.value = 0;
            int level = int.Parse(epAnzeige.GetComponent<Text>().text);
            int levelUp = level + 1;
            epAnzeige.GetComponent<Text>().text = levelUp.ToString();
        }
    }
}
