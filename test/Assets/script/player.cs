using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  
    public GameObject fakel,stoneAgeKnife;
    Inventory inventory;
    // Use this for initialization
    void Start()
    {

        //  Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Spieler"), LayerMask.NameToLayer("Enemy"));

        
        fakel.SetActive(false);
     
        stoneAgeKnife.SetActive(false);

   
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //Feuer An
        if (Input.GetKey(KeyCode.F))
        {
            fakel.SetActive(true);
        }
        else
        {
            fakel.SetActive(false);
        }
        if (Input.GetKey(KeyCode.T))
        {
            stoneAgeKnife.SetActive(true);
        }
        else
        {
            stoneAgeKnife.SetActive(false);
        }
        /* 
         if (Input.GetKeyDown(KeyCode.Q))
         {
             leben.CurrentVal -= 10;
         }
         if (Input.GetKeyDown(KeyCode.T))
         {
             leben.CurrentVal += 10;
         }
         */
        /*SteinWerfen Left maus button if (Input.GetAxisRaw("Fire1")>0)(fireRocket();
        if (Input.GetKeyDown(KeyCode.R))
        {
         //   steineWerfen();
        }*/
    }



    
}
       

