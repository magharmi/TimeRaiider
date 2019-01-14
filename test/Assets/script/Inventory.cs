using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public bool[] isFull;
    public GameObject[] slots;
    public string[] gespeicherteWaffen;
    private GameObject waffe;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            slots[i] = GameObject.Find("Slot" + (i + 1));
            gespeicherteWaffen[i] = PlayerPrefs.GetString("slot" + (i + 1));
            
            if(gespeicherteWaffen[i] == "keule")
            {
                waffe = GameObject.Find("KnochenKeule2InventarBild");
                Instantiate(waffe, slots[i].transform, false);
            }
            else if(gespeicherteWaffen[i] == "speer")
            {
                waffe = GameObject.Find("KnochenkeuleTestInventarBild");
                Instantiate(waffe, slots[i].transform, false);
            }
        }
    }


}
