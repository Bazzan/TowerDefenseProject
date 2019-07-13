using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager Instance;
    Node node;

    [SerializeField] public GameObject buildEffect;
    //public GameObject buildFeedBack;

    private TurretBluePrint turretToBuild;

    private Node selectedNode;
    [SerializeField] private NodeUI nodeUI;


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


    public void SelectNode(Node node)
    {

        if(selectedNode != null)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.HideNodeUI();
    }


    public void SelectTurretToBuild (TurretBluePrint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }


    public TurretBluePrint getTurretToBuild()
    {
        return turretToBuild;
    }


}
