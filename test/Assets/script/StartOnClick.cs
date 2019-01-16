using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOnClick : MonoBehaviour {


    public void StartLevel()
    {
        string lastScene = PlayerPrefs.GetString("letzteScene");
        if (lastScene == "null")
        {
            SceneManager.LoadScene("Storybilder");
        }
        else
        {
            Debug.Log(lastScene);
            SceneManager.LoadScene(lastScene);
        }
    }
	
}
