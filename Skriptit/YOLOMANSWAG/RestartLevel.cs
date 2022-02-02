using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    private PauseScreen pauseScreenClass;

    private void Start()
    {
        pauseScreenClass = GameObject.FindObjectOfType<PauseScreen>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            pauseScreenClass.Retry();
        }
    }
}
