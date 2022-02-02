using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableUI : MonoBehaviour
{
    public GameObject canvas;

    private bool isActive = true;
    public bool allowInput = false;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse2) && allowInput == true)
        {
            if(isActive)
            {
                canvas.SetActive(false);
                isActive = false;
            }
            else
            {
                canvas.SetActive(true);
                isActive = true;
            }
        }
    }
    
    public void DoIt()
    {
        if (isActive)
        {
            canvas.SetActive(false);
            isActive = false;
        }
        else
        {
            canvas.SetActive(true);
            isActive = true;
        }
    }
}
