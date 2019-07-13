using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint{

    public GameObject Prefab;
    public int Cost;
    public GameObject UpgradedPrefab;
    public int UpgradeCost;


    public int GetSellAmount()
    {
        return Cost / 2;
    }
}
