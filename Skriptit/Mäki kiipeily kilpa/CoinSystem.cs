using UnityEngine;
using TMPro;
using System.Collections;

public class CoinSystem : MonoBehaviour
{
    public int money = 0;
    public TMP_Text moneyCounterText;

    private void Start()
    {
        money = PlayerPrefs.GetInt("MoneyAmount", 0);
    }

    private void Update()
    {
        moneyCounterText.text = money.ToString() + " rahaa";
        PlayerPrefs.SetInt("MoneyAmount", money);
    }

    public void AddPoints(int amount = 1)
    {
        money += amount;
        PlayerPrefs.SetInt("MoneyAmount", money);
    }
}