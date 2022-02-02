using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTemporaryAttempts : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("CurrentAttempts", 0);
    }
}
