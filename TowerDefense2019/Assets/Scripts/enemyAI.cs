using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class enemyAI : MonoBehaviour {

    [Header("Attributes")]
    public float speed = 10f;
    //private int wavePointIndex = 0;
    public int health = 100;
    public int value = 50;
    public int dmgCastel;

    [Header("Stuff")]
    public GameObject deathEffect;
    

    [Header("NavMesh")]


    public NavMeshAgent agent;
    public Transform endDestination;
    public bool agentHasPath = false;

    public Transform start;

    private float dist;
    private navMeshManager navManager;
    private LineRenderer linerend;
    private NavMeshPath path;

    


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        linerend = GetComponent<LineRenderer>();
        
    }
    void Start()
    {
        


        if (agent == null)
        {
            Debug.Log("lägg till enemys navMeshAgent i" + gameObject.name);
        }else
        {
            Debug.Log("agent on mesh: " + agent.isOnNavMesh + " agent is activeAndEnabled: " + agent.isActiveAndEnabled);
            NavMesh.CalculatePath(agent.transform.position, endDestination.position, NavMesh.AllAreas, path);
            Debug.Log(path.status);
            agent.SetPath(path);
            Debug.Log(agent.hasPath);
            if (agent.hasPath)
            {
                agentHasPath = true;
            }
            Debug.Log("agent path Corners" + agent.path.corners);

        }

    }

    void Update()
    {

        //dist = agent.remainingDistance;
        ////Debug.Log(dist);
        //if (dist <= 1)
        //{
        //    EndPath();
        //    Debug.Log(dist);
        //}
        //agent.SetPath(enemyPath);

        linerend.positionCount = agent.path.corners.Length;
        linerend.SetPositions(agent.path.corners);
        linerend.enabled = true;

    }


    private void SetDestination()
    {
        if(endDestination != null)
        {
            Vector3 endVector = endDestination.transform.position;
            agent.SetDestination(endVector);
        }
    }

    public void TakeDamage(int dmgCastel)
    {
        health -= dmgCastel;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }



    private void OnTriggerEnter(Collider other) // i ett eget script?
    {
        //Debug.Log("EndPath");
        if (other.gameObject.CompareTag("PathEnd"))
        {
            EndPath();
        }
    }

    public void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }



}
