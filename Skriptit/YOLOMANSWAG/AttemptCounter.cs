using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttemptCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text attemptCounter;
    private int attempts = 0;

    private void Start()
    {
        GetAttempts();
        attempts++;
        UpdateAttempts();
    }

    private void GetAttempts()
    {
        attempts = PlayerPrefs.GetInt("CurrentAttempts", 0);
    }

    private void UpdateAttempts()
    {
        PlayerPrefs.SetInt("CurrentAttempts", attempts);
        attemptCounter.text = "YRITYKSET: " + attempts.ToString();
    }
}
