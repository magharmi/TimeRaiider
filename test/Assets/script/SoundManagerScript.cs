using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip messer_A,dinoWalk,blut1,blutPlatz,crossbow,jump,hit,steinwurf;
    static AudioSource audioSrc;
    // Use this for initialization
    void Start()
    {
        messer_A  = Resources.Load<AudioClip>("messer");
        dinoWalk  = Resources.Load<AudioClip>("dinoWalk");
        blutPlatz = Resources.Load<AudioClip>("BlutPlatzt");
        blut1     = Resources.Load<AudioClip>("Blut1");
        crossbow  = Resources.Load<AudioClip>("crossbow");
        jump      = Resources.Load<AudioClip>("jump");
        hit       = Resources.Load<AudioClip>("hit");
        steinwurf = Resources.Load<AudioClip>("steinwurf");
        audioSrc  = GetComponent<AudioSource>();
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
            case "dinoWalk":
                audioSrc.PlayOneShot(dinoWalk);
                break;
            case "BlutPlatzt":
                audioSrc.PlayOneShot(blutPlatz);
                break;
            case "Blut1":
                audioSrc.PlayOneShot(blut1);
                break;
            case "crossbow":
                audioSrc.PlayOneShot(crossbow);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "steinwurf":
                audioSrc.PlayOneShot(steinwurf);
                break;
        }
    }
}
