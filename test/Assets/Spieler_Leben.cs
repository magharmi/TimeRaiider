﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spieler_Leben : MonoBehaviour
{



    public float fullLeben;
    float currentLeben;
    //public GameObject deathFX;
    [SerializeField]
    Slider sl;

    Spieler_Leben sp;

    public Image geschlagenScreen;
    bool geschlagen;
    Color geschlagenColour = new Color(164f, 15f, 12f, 0.60f);
    float smoothColour = 5f;
    // Use this for initialization
    void Start()
    {
        currentLeben = fullLeben;
        sp = GetComponent<Spieler_Leben>();
        sl.maxValue = fullLeben;
        sl.value = fullLeben;
        currentLeben = fullLeben;
        geschlagen = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (geschlagen)
        {
            geschlagenScreen.color = geschlagenColour;
        }
        else
        {
            geschlagenScreen.color = Color.Lerp(geschlagenScreen.color, Color.clear, smoothColour * Time.deltaTime);
        }
        geschlagen = false;
    }



    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentLeben -= damage;
        SoundManagerScript.PlaySound("hit");
        sl.value = currentLeben;
        geschlagen = true;
        if (currentLeben <= 0)
        {
            makeDead();
        }
    }
    public void addHealth(float healthAmount)
    {
        currentLeben += healthAmount;
        if (currentLeben > fullLeben) currentLeben = fullLeben;
        sl.value = currentLeben;
    }

    public void makeDead()
    {
        geschlagenColour = new Color(164f, 15f, 12f, 100f);
        geschlagenScreen.color = geschlagenColour;
        //  Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

