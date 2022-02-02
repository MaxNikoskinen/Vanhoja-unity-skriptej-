using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWeapon : MonoBehaviour
{
    private bool isBought;

    public void BuyWeaponWeapon(int cost)
    {
        if(!isBought)
        {
            //isBought todeksi jotta samaa ei voi ostaa kaksi kertaa
            isBought = true;

            //Hakee raham‰‰r‰n
            int moneyGet = -1;
            moneyGet = GameManager.Instance.GetMoney();

            //Miinustaa raham‰‰r‰st‰ hinnan
            if(moneyGet >= cost)
            {
                moneyGet -= cost;
            }
            
            //P‰ivitt‰‰ raham‰‰r‰n gamemanageriin
            GameManager.Instance.UpdateMoneyAmount(moneyGet);
        }
    }
}
