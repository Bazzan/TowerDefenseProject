
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBluePrint ArrowTower;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint magicLaserB;

    BuildManager buildmanager;


    private void Start()
    {
        buildmanager = BuildManager.instance;
    }


    public void SelectStandarTurret()
    {
        Debug.Log("Standard turret Selected");
        buildmanager.SelectTurretToBuild(ArrowTower);

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
