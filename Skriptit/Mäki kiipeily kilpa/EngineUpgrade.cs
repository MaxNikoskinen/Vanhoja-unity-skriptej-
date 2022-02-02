using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EngineUpgrade : MonoBehaviour
{
    private CustomRotate customRotate;
    private CoinSystem moneySystem;
    public TMP_Text powerText;

    void Start()
    {
        customRotate = GameObject.FindObjectOfType<CustomRotate>();
        moneySystem = GameObject.FindObjectOfType<CoinSystem>();
    }

    void Update()
    {
        powerText.text = "Moottorin teho: " + customRotate.speed.ToString();
    }

    public void RiseEnginePower()
    {
        if(moneySystem.money >= 50)
        {
            customRotate.MoreEnginePower();
            moneySystem.money -= 50;
        }
    }

    public void LowerEnginePower()
    {
        customRotate.LessEnginePower();
        if (customRotate.speed > 1)
        {
            moneySystem.money += 25;
        }
        else return;
    }
}
