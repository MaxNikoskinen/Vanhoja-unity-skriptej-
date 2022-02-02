using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Data/Newupgradedata", order = 0)]
public class UpgradeData : ScriptableObject
{
    public int upgradeCost;

    // [Modifier("Upgrades")]
    public float speedModifier;
    public float HealthModifier;
    public float damageModifier;
    public float shieldModifier;
    public int magazinesizeModifier;

}
