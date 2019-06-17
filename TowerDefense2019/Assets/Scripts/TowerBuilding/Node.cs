using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour {
    BuildManager buildManager;
    [SerializeField] private Color notEnoughMoney;
    [SerializeField] private Color hoverColor;

    //public Material buildTrue;
    //public Material buildFalse;
    //public GameObject BuildFeedBack;

    
    [SerializeField] private Vector3 positionOffSett;

    [Header ("Optional")]
    public GameObject Turret;

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

        if (!buildManager.CanBuild)
        {
            return;
        }


        if (Turret != null)
        {
            Debug.Log("Already a turret there");
            return;
        }

        buildManager.BuildTurretOn(this);
        NavMeshManager.navMeshManagerInstance.CalcPath();
    }

    void OnMouseEnter()
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
}
