using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip messer_A;
    static AudioSource audioSrc;
    // Use this for initialization
    void Start()
    {
        messer_A = Resources.Load<AudioClip>("messer");
       
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "messer":
                audioSrc.PlayOneShot(messer_A);
                break;
         
        }
    }
}
