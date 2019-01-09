using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorA3 : MonoBehaviour
{

    public string sceneToLoad;
    public Button[] levelButtons;

    // Use this for initialization
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 14; i < levelButtons.Length + 14; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i - 14].interactable = false;
            }
        }
    }

    public void LoadLevel()
    {
        // ausgewähltes Level laden
        SceneManager.LoadScene(sceneToLoad);
    }
}
