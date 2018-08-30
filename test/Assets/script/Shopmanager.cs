using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour {
    public int kontostand;
    public Text kontostandText;

	// Use this for initialization
	void Start () {
        kontostand = PlayerPrefs.GetInt("kontostand");
        kontostandText.text = kontostand.ToString();
	}

    public void ItemKaufen(int itemPreis)
    {
        if(kontostand >= itemPreis)
        {
            Debug.Log("Item gekauft");
            kontostand = kontostand - itemPreis;
            KontostandAktualisieren();
            PlayerPrefs.SetInt("kontostand", kontostand);
        }
    }

    public void KontostandAktualisieren()
    {
        kontostandText.text = kontostand.ToString();
    }

    public void zumShop()
    {
        PlayerPrefs.SetInt("kontostand", kontostand);
        SceneManager.LoadScene("Shop");
        Start();
    }

    public void exitShop()
    {
        SceneManager.LoadScene("test");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
