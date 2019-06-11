using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    Node node;

    public GameObject buildEffect;
    //public GameObject buildFeedBack;

    private TurretBluePrint turretToBuild;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one buildmanager in scene");
            return;
        }
        instance = this;

    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

  
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Check wallet you bum!");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Denero left:" + PlayerStats.Money);
        turretToBuild = null;
    }

    public void SelectTurretToBuild (TurretBluePrint turret)
    {
        turretToBuild = turret;
    }



}
