﻿using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour {
    BuildManager buildManager;

    [SerializeField] private Color notEnoughMoney;
    [SerializeField] private Color hoverColor;

    //public Material buildTrue;
    //public Material buildFalse;
    //public GameObject BuildFeedBack;

    
    [SerializeField] private Vector3 positionOffSett;


    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public GameObject Turret;
    [HideInInspector]
    public bool isUpgraded = false;


    [SerializeField] private GameObject nodeUI;

    private Renderer rend;
    private Color startColor;
    //private GameObject buildFeedback;
   

    void Start()
    {
        buildManager = BuildManager.Instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        //buildFeedback = buildManager.buildFeedBack;
        //Instantiate(BuildFeedBack, GetBuildPosition(), Quaternion.identity);

        //BuildFeedBack.SetActive(false);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSett;
    }


    void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        BuildManager.Instance.DeselectNode();

        // gör så att du kan gömma nodeui genom att klicka på andra torn
        if (nodeUI.activeInHierarchy) // TODO: make so the nodeUi is hidden when you click anything else
        {
            buildManager.DeselectNode();
            return;
        }

        if (Turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.getTurretToBuild());

        //buildManager.BuildTurretOn(this);
        NavMeshManager.navMeshManagerInstance.CalcPath();
    }

    void OnMouseEnter() // TODO: make a child that shows if you can build or not
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
        return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            //buildManager.buildFeedBack.SetActive(true);
            //Transform(buildFeedback)


            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoney;
        }


    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }


    void BuildTurret (TurretBluePrint bluePrint)
    {
        if (PlayerStats.Money < bluePrint.Cost)
        {

            return;
        }
        PlayerStats.Money -= bluePrint.Cost;

        GameObject instanceTurret = Instantiate(bluePrint.Prefab, GetBuildPosition(), Quaternion.identity);
        Turret = instanceTurret;

        turretBluePrint = bluePrint;

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        bluePrint = null;


        //FireEvent?
    }

    //fixa kompilerings fel innan du fortsätter
    public void UpgradeTower() //uppgraderar tornet -> förstör det gamla skapar ett nytt och drar pengar
    {
        if (PlayerStats.Money < turretBluePrint.UpgradeCost)
        {
            Debug.Log("not enough money to upgrade tower");
            return;
        }
        PlayerStats.Money -= turretBluePrint.UpgradeCost;
        Destroy(Turret); 

        GameObject instanceTurret = Instantiate(turretBluePrint.UpgradedPrefab, GetBuildPosition(), Quaternion.identity);
        Turret = instanceTurret;


        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); //upgrade effekt?
        Destroy(effect, 5f);

        isUpgraded = true;


        Debug.Log("turret Upgraded");

        //FireEvent?
    }

    public void SellTurret() // TODO: skapa ett partikel system som ser ut som att tornet går i bitar och hamnar på marken
    {
        PlayerStats.Money += turretBluePrint.GetSellAmount();
        Destroy(Turret);
        turretBluePrint = null;



        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); //upgrade effekt?
        Destroy(effect, 5f);
    }


}
