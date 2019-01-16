using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setMusic(float volume)
    {
        if (volume == 1)
        {
            AudioListener.pause = true;
        }
        else
            AudioListener.pause = false;
        //setVolume(volume);
    }
}
