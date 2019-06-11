using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshManager : MonoBehaviour {

    public NavMeshAgent agent;
    public NavMeshPath path1 , path2 ;

    public GameObject castle;
    public GameObject start;


    private LineRenderer linerend;
    private Vector3 spawn;

    private NavMeshPath navMeshPath;
    private enemyAI enemyAi;

    private GameObject[] enemyList;
    //ArrayList enemyList = new ArrayList();
    
    private void Awake()
    {
        path1 = new NavMeshPath();
        enemyAi = GetComponent<enemyAI>();
        spawn = start.transform.position;
        linerend = GetComponent<LineRenderer>();
        calcPath();

        Debug.Log("done" + agent.remainingDistance + agent.hasPath + agent.pathPending);
    }

    private void Update()
    {

        // kansek en colliader som känner av om det är en enemy i start och ger den path på det sättet?
 

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.transform.SetPositionAndRotation(spawn, Quaternion.identity);
        }
        //linerend.positionCount = agent.path.corners.Length;
        //linerend.SetPositions(agent.path.corners);

        linerend.positionCount = path1.corners.Length;
        linerend.SetPositions(path1.corners);
        linerend.enabled = true;

    }

    public void calcPath()
    {
        Debug.Log("new path calced");
        NavMesh.CalculatePath(start.gameObject.transform.position, castle.transform.position, NavMesh.AllAreas, path1);
        Debug.Log(path1.status+ "1");
        path2 = path1;
        Debug.Log(path2.status + "2");
    }


    private void OnMouseDown()
    {
        calcPath();
        agent.SetPath(path1);

        Debug.Log("done" + agent.remainingDistance + agent.hasPath + agent.pathPending);

    }
    //public void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("hello");
    //    if (other.CompareTag("Enemy") && enemyAi.hasPath == false)
    //    {
    //        agent.SetPath(path1);
    //        Debug.Log("start Trigger");
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("hello");
        //if (other.CompareTag("Enemy") && enemyAi.hasPath == false)
        {
            agent.SetPath(path1);
            Debug.Log("start Trigger");
        }
    }

}
