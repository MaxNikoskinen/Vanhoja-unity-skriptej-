using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsBackButton : MonoBehaviour
{
    private Player playerClass;
    private PauseScreen pauseScreenClass;

    private void Start()
    {
        playerClass = GameObject.FindObjectOfType<Player>();
        pauseScreenClass = GameObject.FindObjectOfType<PauseScreen>();
    }

    public void ButtonPress()
    {
        if(playerClass.levelCompleted)
        {
            playerClass.winScreen.SetActive(true);
        }
        else if(!playerClass.levelCompleted)
        {
            pauseScreenClass.pauseScreen.SetActive(true);
        }
    }
}
