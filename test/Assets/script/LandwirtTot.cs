using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandwirtTot : MonoBehaviour
{


    private GameObject MainCamera, BosskampfKamera, BosskampfWandRechts;

    // Use this for initialization
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        BosskampfKamera = GameObject.Find("Bosskampf Kamera");
        BosskampfWandRechts = GameObject.Find("Bosskampf Wand rechts");
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.GetComponent<EnemyHealthBar>().currentHealth <= 10)
        {
            MainCamera.SetActive(true);
            Destroy(BosskampfKamera);
            Destroy(BosskampfWandRechts);
        }
    }
}
