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
    [SerializeField] private Transform cameraToRotateTo;

    private Vector3 dirToCamera;
    private void FixedUpdate()
    {
        RotateToCamera();
    }




    public void SetTarget(Node nodeTarget)
    {
        target = nodeTarget;

        transform.position = target.GetBuildPosition();


        if (!target.isUpgradedToLVL3)
        {
            upgradeCost.text = "$" + target.turretBluePrint.GetUpgradeCost();
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

    private void RotateToCamera()//rotates the ui against the camera
    {
        dirToCamera = (transform.position - cameraToRotateTo.position).normalized;
        Quaternion rotationToCamera = Quaternion.LookRotation(new Vector3(dirToCamera.x, dirToCamera.y, dirToCamera.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToCamera, 0.5f);
    }


}
