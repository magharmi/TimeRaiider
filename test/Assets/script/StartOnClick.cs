using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOnClick : MonoBehaviour {


    public void StartLevel()
    {
        string lastScene = PlayerPrefs.GetString("letzteScene");
        if (lastScene == null)
        {
            SceneManager.LoadScene("test");
        }
        else
        {
            SceneManager.LoadScene(lastScene);
        }
    }
	
}
