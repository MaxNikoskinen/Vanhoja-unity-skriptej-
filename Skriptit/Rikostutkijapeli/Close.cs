using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject gameObjectToClose;

    public void CloseIt()
    {
        gameObjectToClose.SetActive(false);
    }
}
