using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGraphy : MonoBehaviour
{
    public GameObject graphyCanvas;

    private bool isEnabled = false;
    private int isEnabledNumber = 0;

    private void Start()
    {
        isEnabledNumber = PlayerPrefs.GetInt("GraphyEnabled", 0);

        if(isEnabledNumber == 0)
        {
            DisableGraphyUI();
        }
        else if(isEnabledNumber == 1)
        {
            EnableGraphyUI();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (isEnabled == false)
            {
                EnableGraphyUI();
            }
            else
            {
                DisableGraphyUI();
            }
        }
    }

    private void EnableGraphyUI()
    {
        isEnabled = true;
        graphyCanvas.SetActive(true);
        isEnabledNumber = 1;
        PlayerPrefs.SetInt("GraphyEnabled", isEnabledNumber);
    }

    private void DisableGraphyUI()
    {
        isEnabled = false;
        graphyCanvas.SetActive(false);
        isEnabledNumber = 0;
        PlayerPrefs.SetInt("GraphyEnabled", isEnabledNumber);
    }
}
