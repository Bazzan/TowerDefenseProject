using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshManager : MonoBehaviour
{
    [SerializeField] private Transform castle;


    private NavMeshAgent agent;
    [SerializeField] private static NavMeshPath path;
    private LineRenderer linerend;
    private Vector3 spawn;

    public static NavMeshManager navMeshManagerInstance;

    private void Awake()
    {


        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        linerend = GetComponent<LineRenderer>();

        if (navMeshManagerInstance != null)
        {
            Debug.Log("navmeshmanager.cs signelton not working");
            return;
        }
        else
        {
            navMeshManagerInstance = this;
        }


    }
    private void Start()
    {
        CalcPath();
    }

    private void Update()
    {

        linerend.positionCount = path.corners.Length;
        linerend.SetPositions(path.corners);
        linerend.enabled = true;
        Debug.Log(path.corners.Length);

        CalcPath();



    }



    public void CalcPath()
    {
        //Debug.Log(transform.position + " " + castle.position + " " + NavMesh.AllAreas + " " + path.ToString());
        NavMesh.CalculatePath(transform.position, castle.position, NavMesh.AllAreas, path);
        //Debug.Log(path.corners.Length);

    }

    public NavMeshPath GetPath()
    {
        if (path != null)
        {
            return path;
        }
        else
        {
            Debug.Log("path == null");
            return null;
        }

    }
}
