using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public Dropdown resolutiondropdown;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutiondropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolution = 0;
        for(int i = 0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }
        resolutiondropdown.AddOptions(options);
        resolutiondropdown.value = currentResolution;
        resolutiondropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resol = resolutions[resolutionIndex];
        Screen.SetResolution(resol.width, resol.height, Screen.fullScreen);
    }

    public void setVolume(float volume)
    {
        mixer.SetFloat("volumeMixer", volume);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
