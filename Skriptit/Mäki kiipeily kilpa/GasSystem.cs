using System.Collections;
using TMPro;
using UnityEngine;

public class GasSystem : MonoBehaviour
{
    private float time = 0.0f;
    private float time2 = 0.0f;
    public int amountOfGasoline = 100;
    public TMP_Text amountOfGasText;
    public bool isGameOver = false;
    public GameObject gameOverScreen;
    public GameObject countdown;
    public TMP_Text countdownText;
    public int countdownTime = 5;
    bool isCounterEnabled = false;

    void Update()
    {
        amountOfGasText.text = amountOfGasoline.ToString() + " bensaa";
        countdownText.text = countdownTime.ToString();

        if (amountOfGasoline <= 0)
        {
            isGameOver = true;
            GameOver();

            if (isCounterEnabled == false)
            {
                countdown.SetActive(true);
                isCounterEnabled = true;
            }
        }
    }

    private void FixedUpdate()
    {
        time = time + Time.fixedDeltaTime;
        time2 = time2 + Time.fixedDeltaTime;
        if (!isGameOver)
        {
            if (time > 0.5f)
            {
                amountOfGasoline--;
                time = 0.0f;
            }
        }
        else return;
    }

    public void RefillGas()
    {
        amountOfGasoline = 100;
    }

    public void EmptyGas()
    {
        amountOfGasoline = 0;
    }

    public void GameOver()
    {
        if (time2 > 1f)
        {
            countdownTime--;
            time2 = 0f;
        }

        if (time > 5f)
        {
            gameOverScreen.SetActive(true);
            time = 0.0f;
            countdown.SetActive(false);
        } 
    }
}
