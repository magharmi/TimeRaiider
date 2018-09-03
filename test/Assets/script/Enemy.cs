using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public static float healthAmount;




    void Start()
    {

        healthAmount = 1;

    }

    void Update()
    {
        if(healthAmount <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("bullet"))
        {
            healthAmount -= 0.1f;
        }
    }
}
