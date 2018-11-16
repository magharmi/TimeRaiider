using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

  
    //  public float moneyAmountG;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spieler")
        {
            SpielControlRusse.moneyAmount +=1;
            Destroy(gameObject);
        }
    }
}

