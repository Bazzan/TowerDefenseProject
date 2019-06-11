using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class navMeshRebuild : MonoBehaviour {

    //public NavMeshSurface ground;
    public NavMeshAgent agent;
    public NavMeshPath path;
    public GameObject sphere;
    //public Transform endPosition;
    public GameObject castle;
    
    //public bool pathAvailable;
   


    private LineRenderer linerend;
    private Vector3 spawn;

    private void Awake()
    {
        path = new NavMeshPath();
        //endPosition = castle.gameObject.transform;

        //ground.BuildNavMesh();
        spawn = agent.transform.position;
        linerend = GetComponent<LineRenderer>();
        calcPath();
    }
    //private void Start()
    //{
    //    path = new NavMeshPath();
    //    //endPosition = castle.gameObject.transform;

    //    //ground.BuildNavMesh();
    //    spawn = agent.transform.position;
    //    linerend = GetComponent<LineRenderer>();
    //    calcPath();
    //}

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.transform.SetPositionAndRotation(spawn, Quaternion.identity);
        }


        linerend.positionCount = agent.path.corners.Length;
        linerend.SetPositions(agent.path.corners);
        linerend.enabled = true;







    }

    public void calcPath()
    {
        //spawnpoint.CalculatePath(endPosition.position, navPath);
        Debug.Log("new path calced");
        NavMesh.CalculatePath(sphere.gameObject.transform.position, castle.transform.position, NavMesh.AllAreas, path);
        Debug.Log(path.status);
    }

    //bool checkPath()
    //{

    //    if (navPath.status != NavMeshPathStatus.PathComplete)
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        return true;

    //    }

    //}

    private void OnMouseDown()
    {
        calcPath();
        agent.SetPath(path);
        
        Debug.Log("done" + agent.remainingDistance + agent.hasPath + agent.pathPending);
        
        //agent.SetDestination(endPosition.position);
       
        
        //if (checkPath())
        //{
        //    Debug.Log(checkPath());

        //}
        //else
        //{
        //    Debug.Log("false");
        //}
    }

    //void OnDrawGizmosSelected()
    //{

    //    var nav = GetComponent<NavMeshAgent>();
    //    if (nav == null || nav.path == null)
    //        return;

    //    var line = this.GetComponent<LineRenderer>();
    //    if (line == null)
    //    {
    //        line = this.gameObject.AddComponent<LineRenderer>();
    //        line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.yellow };
    //        line.SetWidth(0.5f, 0.5f);
    //        line.SetColors(Color.yellow, Color.yellow);
    //    }

    //    var path = nav.path;

    //    line.SetVertexCount(path.corners.Length);

    //    for (int i = 0; i < path.corners.Length; i++)
    //    {
    //        line.SetPosition(i, path.corners[i]);
    //    }

    //}

    //// Use this for initialization
    //void Start () {
    //       ground.BuildNavMesh();
    //}

    //public void updateNavM()
    //{
    //    NavMeshBuilder.UpdateNavMeshData();
    //}

}
