using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ziel : MonoBehaviour
{
    public string level;
    public int LevelToUnlock = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spieler")
        {
            Debug.Log("ziel erreicht");
            SceneManager.LoadScene(level);
            PlayerPrefs.SetInt("levelReached", LevelToUnlock);
            PlayerPrefs.SetString("letzteScene", level);
        }
    }

}
