using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllAttemptsText : MonoBehaviour
{
    private AllAttemptsCounter allAttemptsCounterClass;

    [SerializeField] private TMP_Text counter1;
    [SerializeField] private TMP_Text counter2;
    [SerializeField] private TMP_Text counter3;
    [SerializeField] private TMP_Text counter4;

    private int counterAmount1;
    private int counterAmount2;
    private int counterAmount3;
    private int counterAmount4;

    private void Start()
    {
        allAttemptsCounterClass = GameObject.FindObjectOfType<AllAttemptsCounter>();

        GetLevel1Deaths();
        GetLevel2Deaths();
        GetLevel3Deaths();
        GetLevel4Deaths();

        counter1.text = "YRITYKSIÄ: " + counterAmount1.ToString();
        counter2.text = "YRITYKSIÄ: " + counterAmount2.ToString();
        counter3.text = "YRITYKSIÄ: " + counterAmount3.ToString();
        counter4.text = "YRITYKSIÄ: " + counterAmount4.ToString();
    }

    private void GetLevel1Deaths()
    {
        counterAmount1 = PlayerPrefs.GetInt("Level1Deaths", 0);
    }

    private void GetLevel2Deaths()
    {
        counterAmount2 = PlayerPrefs.GetInt("Level2Deaths", 0);
    }

    private void GetLevel3Deaths()
    {
        counterAmount3 = PlayerPrefs.GetInt("Level3Deaths", 0);
    }

    private void GetLevel4Deaths()
    {
        counterAmount4 = PlayerPrefs.GetInt("Level4Deaths", 0);
    }
}
