using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navAgent : MonoBehaviour
{

    navMeshRebuild navRebuild;
    public GameObject castle;


    public NavMeshAgent agent;
    private NavMeshPath path;
    private Vector3 spawn;
    private LineRenderer linerend;
    // Use this for initialization
    void Start()
    {
        path = new NavMeshPath();
        agent = GetComponent<NavMeshAgent>();
        spawn = agent.transform.position;
        linerend = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.transform.SetPositionAndRotation(spawn, Quaternion.identity);
        }

        //for (int i = 0; i < navPath.corners.Length - 1; i++)
        //{
        //    Debug.DrawLine(navPath.corners[i], navPath.corners[i + 1], Color.red);
        //}

        linerend.positionCount = agent.path.corners.Length;
        linerend.SetPositions(agent.path.corners);
        linerend.enabled = true;



    }
    public void calcPath()
    {
        //spawnpoint.CalculatePath(endPosition.position, navPath);
        Debug.Log("new path calced");
        NavMesh.CalculatePath(agent.gameObject.transform.position, castle.transform.position, NavMesh.AllAreas, path);
        Debug.Log(path.status);
    }

    private void OnMouseDown()
    {
        calcPath();
        agent.SetPath(path);

        Debug.Log("done" + agent.remainingDistance + agent.hasPath + agent.pathPending);

    }
}