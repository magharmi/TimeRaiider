using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {
    int waffe1;
	int moneyAmount;
	int isRifleSold,isRifleSold2,isRifleSold3;
    
	public Text moneyAmountText;
	public Text riflePrice,riflePrice2,riflePrice3;
	public Button buyButton1,buyButton2,buyButton3;

    private Scene aktuelleScene;

	// Use this for initialization
	void Start () {
		moneyAmount = PlayerPrefs.GetInt ("MoneyAmount");
        aktuelleScene = SceneManager.GetActiveScene();
       

    }
	
	// Update is called once per frame
	void Update () {
		
		moneyAmountText.text = "Gold: " + moneyAmount.ToString();

		isRifleSold  = PlayerPrefs.GetInt ("IsRifleSold");
        isRifleSold2 = PlayerPrefs.GetInt ("IsRifleSold2");
        isRifleSold3 = PlayerPrefs.GetInt ("IsRifleSold3");

        if (moneyAmount >= 5 && isRifleSold == 0)
			buyButton1.interactable = true;
            
		else
			buyButton1.interactable = false;


        if (moneyAmount >= 5 && isRifleSold2 == 0)
            buyButton2.interactable = true;

        else
            buyButton2.interactable = false;


        if (moneyAmount >= 5 && isRifleSold3 == 0)
            buyButton3.interactable = true;

        else
            buyButton3.interactable = false;
    }

	public void buyRifle()
	{
		moneyAmount -= 5;
		PlayerPrefs.SetInt ("IsRifleSold", 1);
		riflePrice.text = "Verkauft!";
		buyButton1.gameObject.SetActive (false);
	}
    public void buyRifle1()
    {
        moneyAmount -= 10;
        PlayerPrefs.SetInt("IsRifleSold2", 1);
        riflePrice2.text = "Verkauft!";
        buyButton2.gameObject.SetActive(false);
    }
    public void buyRifle2()
    {
        moneyAmount -= 15;
        PlayerPrefs.SetInt("IsRifleSold3", 1);
        riflePrice3.text = "Verkauft!";
        buyButton3.gameObject.SetActive(false);
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
            SceneManager.LoadScene("Raumstation");
        }
      

    }

	public void resetPlayerPrefs()
	{
		moneyAmount = 0;
		buyButton1.gameObject.SetActive (true);
        buyButton2.gameObject.SetActive(true);
        buyButton3.gameObject.SetActive(true);
        riflePrice.text  = "Preis: 5 Gold";
        riflePrice2.text = "Preis: 10 Gold";
        riflePrice3.text = "Preis: 15 Gold";
        PlayerPrefs.DeleteAll ();
	}

}
