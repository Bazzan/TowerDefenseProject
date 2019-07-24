using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint{

    public GameObject Prefab;
    public float Cost;
    public GameObject FirstUpgradedPrefab;
    public float UpgradeCost;
    public GameObject SecondUpgradedPrefab;
    

    public int GetSellAmount()
    {
        float sellAmount = Cost / 2;
        return (int)sellAmount;
    }

    public int GetUpgradeCost()
    {
        UpgradeCost = Cost * 1.5f;
        return (int)UpgradeCost;
    }

    public int GetSecondUpgradeCost()
    {
        UpgradeCost = Cost * 2.5f;
        return (int)UpgradeCost;
    }

    public int GetCost()
    {
        return (int)Cost;
    }
}
