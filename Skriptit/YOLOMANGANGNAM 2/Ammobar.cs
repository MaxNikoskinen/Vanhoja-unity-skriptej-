using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammobar : MonoBehaviour
{
    public int maximum;
    public int current;
    public Image fill;

    private void Update()
    {
        GetCurrentFill();
    }

    private void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        fill.fillAmount = fillAmount;
    }
}
