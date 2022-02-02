using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public GameObject Light;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(Light.active == false)
            {
                Light.active = true;
            }
            else
            {
                Light.active = false;
            }
        }
          
        
    }

}

