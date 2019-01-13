using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour {

    public Slider sl;
    public Text levelAnzeige;
    private GameObject slider;
    private Text moneyText;
	public static int moneyAmount;
	int isRifleSold;
    public string shopSzene;
	public GameObject rifle;

	// Use this for initialization
	void Start () {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
        isRifleSold = PlayerPrefs.GetInt("IsRifleSold");
        slider = GameObject.Find("Slider");
        sl = GameObject.Find("SliderEP").GetComponent<Slider>();
        moneyText = GameObject.Find("GoldZaehler").GetComponent<Text>();
        levelAnzeige = GameObject.Find("LvlAnzeige").GetComponent<Text>();
        moneyText.text = "Gold: " + moneyAmount.ToString();

        sl.maxValue = 100;
        sl.value    = 0;

        sl.value = PlayerPrefs.GetFloat("EPValue");
        levelAnzeige.text = PlayerPrefs.GetInt("SpielerLevel").ToString();

		if (isRifleSold == 1)
			rifle.SetActive (true);
		else
			rifle.SetActive (false);
	}

	public void gotoShop()
	{
		PlayerPrefs.SetInt ("MoneyAmount", moneyAmount);
        PlayerPrefs.SetFloat("EPValue", sl.value);
        PlayerPrefs.SetInt("SpielerLevel", int.Parse(levelAnzeige.text));
		SceneManager.LoadScene (shopSzene);
	}

    public void addEP(float epAmount)
    {
        sl.value += epAmount;
        if (sl.value >= sl.maxValue)
        {
            sl.value = 0;
            int level = int.Parse(levelAnzeige.GetComponent<Text>().text);
            int levelUp = level + 1;
            levelAnzeige.GetComponent<Text>().text = levelUp.ToString();
        }
    }

    public void addGold(int goldAmount)
    {
        moneyAmount += goldAmount;
        moneyText.text = "Gold: " + moneyAmount.ToString();
    }
    
    public int getGold()
    {
        return moneyAmount;
    }
}
