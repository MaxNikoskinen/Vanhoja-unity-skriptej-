using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishArea : MonoBehaviour
{
    [SerializeField] private List<string> TriggerTags = new List<string>();
    private LevelTime levelTimeScript;

    private bool isDone;

    private void Start()
    {
        levelTimeScript = FindObjectOfType<LevelTime>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (TriggerTags.Contains(collision.gameObject.tag) && !isDone)
        {
            //isDone todeksi jotta t‰m‰ metodi ei toistu kuin kerran
            isDone = true;

            //Pys‰ytt‰‰ aikalaskurin p‰ivittt‰misen
            levelTimeScript.updateTime = false;

            //Hakee raha m‰‰r‰n joka on 0
            int moneyGet = -1;
            moneyGet = GameManager.Instance.GetMoney();

            //Muuntaa rahan liukuluvuksi
            float floatMoney;
            floatMoney = moneyGet;

            //Lis‰‰ rahaan 10000
            floatMoney += 10000;

            //Jakaa tasoajan kahdella ja tallentaa sen muuttujaan
            float timeValueNew = levelTimeScript.timeValue / 2;

            //Jakaa raham‰‰r‰n muunnetulla tasoajalla
            floatMoney /= timeValueNew;

            //Muuntaa raham‰‰r‰n takaisin kokonaisluvuksi
            int intMoney;
            intMoney = (int)floatMoney;

            //Ottaa muunnetun raham‰‰r‰n, lis‰‰ siihen 5000, ja p‰ivitt‰‰ sen gamemanageriin
            GameManager.Instance.UpdateMoneyAmount(intMoney + 5000);
        }
    }
}
