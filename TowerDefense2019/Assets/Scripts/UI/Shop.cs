
using UnityEngine;

public class Shop : MonoBehaviour {

    [SerializeField] private TurretBluePrint arrowTower;
    [SerializeField] private TurretBluePrint bombTower;
    [SerializeField] private TurretBluePrint magicLaser;
    [SerializeField] private TurretBluePrint aoETurret;

    private BuildManager buildmanager;


    private void Start()
    {
        buildmanager = BuildManager.Instance;
    }


    public void SelectStandarTurret()
    {
        //Debug.Log("Standard turret Selected");
        buildmanager.SelectTurretToBuild(arrowTower);

    }

    public void SelectMissileLauncher()
    {
        //Debug.Log("Missile Launcher Selected");
        buildmanager.SelectTurretToBuild(bombTower);
    }

    public void SelectMagicLaser()
    {
        //Debug.Log("Magic Laser Selected");
        buildmanager.SelectTurretToBuild(magicLaser);
    }

    public void SelectAoETower()
    {
        buildmanager.SelectTurretToBuild(aoETurret);
    }


}
