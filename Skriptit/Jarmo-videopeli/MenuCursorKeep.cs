using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCursorKeep : MonoBehaviour
{
    private bool buyScreenActiveweapon;
    private bool setCursor;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!buyScreenActiveweapon)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }

        if(setCursor)
        {

        }
    }
}
