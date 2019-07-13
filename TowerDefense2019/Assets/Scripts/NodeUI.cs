using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{

    [SerializeField] public GameObject ui;
    private Node target;
    [SerializeField] private Text upgradeCost;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Text sellAmount;

    public void SetTarget(Node nodeTarget)
    {
        target = nodeTarget;

        transform.position = target.GetBuildPosition();


        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBluePrint.UpgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "MAX LvL";
        }

        sellAmount.text = "$" + target.turretBluePrint.GetSellAmount();





        ui.SetActive(true);
    }

    public bool GetActive()
    {
        return ui.activeInHierarchy;
    }

    public void HideNodeUI()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTower();
        BuildManager.Instance.DeselectNode();

    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.Instance.DeselectNode();
    }

}
