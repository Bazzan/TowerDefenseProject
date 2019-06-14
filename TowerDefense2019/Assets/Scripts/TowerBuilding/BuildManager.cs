using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager Instance;
    Node node;

    [SerializeField] private GameObject buildEffect;
    //public GameObject buildFeedBack;

    private TurretBluePrint turretToBuild;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("more than one buildmanager in scene");
            return;
        }
        Instance = this;

    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.Cost; } }

  
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.Cost)
        {
            //Debug.Log("Check wallet you bum!");
            return;
        }
        PlayerStats.Money -= turretToBuild.Cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.Prefab, node.GetBuildPosition(), Quaternion.identity);
        node.Turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        //Debug.Log("Turret build! Denero left:" + PlayerStats.Money);
        turretToBuild = null;
    }

    public void SelectTurretToBuild (TurretBluePrint turret)
    {
        turretToBuild = turret;
    }



}
