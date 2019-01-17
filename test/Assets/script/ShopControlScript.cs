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
    public int preis1, preis2, preis3;
	public Button buyButton1,buyButton2,buyButton3;
    private int waffe2 = 0;
    private int waffe3 = 1;
    private int waffe4 = 2;

    private Scene aktuelleScene;

	// Use this for initialization
	void Start () {
		moneyAmount = PlayerPrefs.GetInt ("MoneyAmount");
        aktuelleScene = SceneManager.GetActiveScene();

        Debug.Log(buyButton1.ToString());

    }
	
	// Update is called once per frame
	void Update () {
		
		moneyAmountText.text = "Gold: " + moneyAmount.ToString();

		isRifleSold  = PlayerPrefs.GetInt ("IsRifleSold");
        isRifleSold2 = PlayerPrefs.GetInt ("IsRifleSold2");
        isRifleSold3 = PlayerPrefs.GetInt ("IsRifleSold3");

        if (moneyAmount >= preis1 && isRifleSold == 0)
			buyButton1.interactable = true;
            
		else
			buyButton1.interactable = false;


        if (moneyAmount >= preis2 && isRifleSold2 == 0)
            buyButton2.interactable = true;

        else
            buyButton2.interactable = false;


        if (moneyAmount >= preis3 && isRifleSold3 == 0)
            buyButton3.interactable = true;

        else
            buyButton3.interactable = false;
    }

    /*
    public int vergleicheWaffe()
    {
        Debug.Log("Starte Vergleich");
        if (buyButton1.ToString() == "KnochenKeule1_Button (UnityEngine.UI.Button)")
        {
            Debug.Log("Vergleich 1");
            return 1;
        }
        else if (buyButton2.ToString() == "KnochenKeule2_Button (UnityEngine.UI.Button)")
        {
            Debug.Log("Vergleich 2");
            return 2;
        }
        else if (buyButton3.ToString() == "Axt_Button (UnityEngine.UI.Button)")
        {
            Debug.Log("Vergleich 3");
            return 3;
        }
        else
        {
            Debug.Log("Vergleich 0");
            return 0;
        }
    }
    */

    public void setWaffenIDs()
    {

        if (aktuelleScene.name == "ShopStoneAge")
        {
            waffe2 = 0;
            waffe3 = 1;
            waffe4 = 2;
        }
        else if (aktuelleScene.name == "ShopWueste")
        {
            waffe2 = 3;
            waffe3 = 4;
            waffe4 = 5;
        }
        else if (aktuelleScene.name == "ShopRom")
        {
            waffe2 = 6;
            waffe3 = 7;
            waffe4 = 8;
        }
        else if (aktuelleScene.name == "ShopZukunft")
        {
            waffe2 = 9;
            waffe3 = 10;
            waffe4 = 11;
        }


    }

    public void buyRifle()
	{
        if (moneyAmount >= preis1 == true)
        {
            /*
            buyButton2 = null;
            buyButton3 = null;
            PlayerPrefs.SetInt("Waffennummer", vergleicheWaffe());
            Debug.Log(vergleicheWaffe());
            */
            setWaffenIDs();
            PlayerPrefs.SetInt("Waffennummer", waffe2);
            moneyAmount -= preis1;
            PlayerPrefs.SetInt("IsRifleSold", 1);
            riflePrice.text = "Verkauft!";
            buyButton1.gameObject.SetActive(false);
        }
	}
    public void buyRifle1()
    {
        if (moneyAmount >= preis2 == true)
        {
            /*buyButton1 = null;
            buyButton3 = null;
            PlayerPrefs.SetInt("Waffennummer", vergleicheWaffe());
            */
            setWaffenIDs();
            PlayerPrefs.SetInt("Waffennummer", waffe3);
            moneyAmount -= preis2;
            PlayerPrefs.SetInt("IsRifleSold2", 1);
            riflePrice2.text = "Verkauft!";
            buyButton2.gameObject.SetActive(false);
        }
    }
    public void buyRifle2()
    {
        if (moneyAmount >= preis3 == true)
        {
            /*buyButton1 = null;
            buyButton2 = null;
            PlayerPrefs.SetInt("Waffennummer", vergleicheWaffe());
            */
            setWaffenIDs();
            PlayerPrefs.SetInt("Waffennummer", waffe4);
            moneyAmount -= preis3;
            PlayerPrefs.SetInt("IsRifleSold3", 1);
            riflePrice3.text = "Verkauft!";
            buyButton3.gameObject.SetActive(false);
        }
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
