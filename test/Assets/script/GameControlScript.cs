using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour {

    [SerializeField]
    public Slider sl;

    [SerializeField]
    Text epAnzeige;

    private GameObject slider;
    public float levelEp;
    private float currentLevel;
    public float fullLevel;


    

    public Text moneyText;
	public static int moneyAmount;
	int isRifleSold;
	public GameObject rifle;

	// Use this for initialization
	void Start () {
        slider = GameObject.Find("SliderEP");

        sl = slider.GetComponent<Slider>();

        currentLevel = fullLevel;
        
        sl.maxValue = currentLevel;
        sl.value    = currentLevel;

        currentLevel = fullLevel;
        


        moneyAmount = PlayerPrefs.GetInt ("MoneyAmount");
		isRifleSold = PlayerPrefs.GetInt ("IsRifleSold");

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
		SceneManager.LoadScene ("ShopStoneAge");
	}

    public void addEP(float epAmount)
    {
        currentLevel -= epAmount;
        if (currentLevel > fullLevel) currentLevel = fullLevel;
        sl.value = currentLevel;
    }
}
