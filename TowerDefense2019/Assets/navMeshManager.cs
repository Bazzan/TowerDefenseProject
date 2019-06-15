using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour {

    private NavMeshAgent agent;
    public NavMeshPath path ;

    public Transform castle;
    //public GameObject start;


    private LineRenderer linerend;
    private Vector3 spawn;

    public static NavMeshManager navMeshManagerInstance;

    private void Awake()
    {
        if(navMeshManagerInstance != null)
        {
            return;
        }
        else
        {
            navMeshManagerInstance = this;
        }
        agent = GetComponent<NavMeshAgent>();

        CalcPath();

        path = new NavMeshPath();
    }


    private void Update()
    {

        linerend.positionCount = path.corners.Length;
        linerend.SetPositions(path.corners);
        linerend.enabled = true;
    }

    

    public void CalcPath()
    {
        NavMesh.CalculatePath(transform.position, castle.position,NavMesh.AllAreas , path);
    }

    public NavMeshPath GetPath()
    {
        return path;
    }
}
