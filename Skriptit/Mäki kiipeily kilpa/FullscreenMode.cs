using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FullscreenMode : MonoBehaviour
{
    public TMP_Dropdown fullscreenModeDropdown;

    void Start()
    {
        fullscreenModeDropdown.value = PlayerPrefs.GetInt("FullscreenMode", 0);
    }

    public void SetFullscreenMode(int fullscreenMode)
    {
        if(fullscreenMode == 0)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else if (fullscreenMode == 1)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

        PlayerPrefs.SetInt("FullscreenMode", fullscreenMode);
    }
}
