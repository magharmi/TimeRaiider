using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {

	int moneyAmount;
	int isRifleSold;

	public Text moneyAmountText;
	public Text riflePrice;
	public Button buyButton;

    private Scene aktuelleScene;

	// Use this for initialization
	void Start () {
		moneyAmount = PlayerPrefs.GetInt ("MoneyAmount");
        aktuelleScene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		
		moneyAmountText.text = "Gold: " + moneyAmount.ToString() + "Gold";

		isRifleSold = PlayerPrefs.GetInt ("IsRifleSold");

		if (moneyAmount >= 5 && isRifleSold == 0)
			buyButton.interactable = true;
		else
			buyButton.interactable = false;	
	}

	public void buyRifle()
	{
		moneyAmount -= 5;
		PlayerPrefs.SetInt ("IsRifleSold", 1);
		riflePrice.text = "Verkauft!";
		buyButton.gameObject.SetActive (false);
	}

	public void exitShop()
	{
		PlayerPrefs.SetInt ("MoneyAmount", moneyAmount);
        if (aktuelleScene.name == "ShopStoneAge")
        {
            SceneManager.LoadScene("dorf");
        }
        else if (aktuelleScene.name == "ShopWueste")
        {
            SceneManager.LoadScene("Stadt");
        }
        else if (aktuelleScene.name == "ShopRom")
        {
            SceneManager.LoadScene("Rom");
        }
        else if (aktuelleScene.name == "ShopZukunft")
        {
            SceneManager.LoadScene("Haus");
        }
    }

	public void resetPlayerPrefs()
	{
		moneyAmount = 0;
		buyButton.gameObject.SetActive (true);
		riflePrice.text = "Preis: 5 Gold";
		PlayerPrefs.DeleteAll ();
	}

}
