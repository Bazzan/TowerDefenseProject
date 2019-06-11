
using UnityEngine;

public class Shop : MonoBehaviour {

    [SerializeField] private TurretBluePrint arrowTower;
    [SerializeField] private TurretBluePrint missileLauncher;
    [SerializeField] private TurretBluePrint magicLaserB;

    private BuildManager buildmanager;


    private void Start()
    {
        buildmanager = BuildManager.Instance;
    }


    public void SelectStandarTurret()
    {
        Debug.Log("Standard turret Selected");
        buildmanager.SelectTurretToBuild(arrowTower);

    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildmanager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectMagicLaser()
    {
        Debug.Log("Magic Laser Selected");
        buildmanager.SelectTurretToBuild(magicLaserB);
    }
}
