using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableConsole : MonoBehaviour
{
    public GameObject consoleUI;

    private bool isEnabled = false;
    private int isEnabledNumber = 0;

    public bool isLevel = true;

    public PlayerMovementCC playerMovementScript = null;
    public MouseLookCC mouseLookScript = null;

    private ConsoleManager consoleManagerScript;

    private void Start()
    {
        consoleManagerScript = GetComponent<ConsoleManager>();
        isEnabledNumber = PlayerPrefs.GetInt("ConsoleEnabled", 0);

        if (isEnabledNumber == 0)
        {
            DisableConsoleUI();
        }
        else if (isEnabledNumber == 1)
        {
            EnableConsoleUI();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (isEnabled == false)
            {
                EnableConsoleUI();
            }
            else
            {
                DisableConsoleUI();
            }
        }
    }

    private void EnableConsoleUI()
    {
        isEnabled = true;
        consoleUI.SetActive(true);
        isEnabledNumber = 1;
        PlayerPrefs.SetInt("ConsoleEnabled", isEnabledNumber);
        consoleManagerScript.consoleInput.Select();
        consoleManagerScript.consoleInput.ActivateInputField();
        if(isLevel == true)
        {
            mouseLookScript.allowLooking = false;
            playerMovementScript.allowMovement = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        
    }

    private void DisableConsoleUI()
    {
        isEnabled = false;
        consoleUI.SetActive(false);
        isEnabledNumber = 0;
        PlayerPrefs.SetInt("ConsoleEnabled", isEnabledNumber);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        if(isLevel == true)
        {
            mouseLookScript.allowLooking = true;
            playerMovementScript.allowMovement = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }
}
