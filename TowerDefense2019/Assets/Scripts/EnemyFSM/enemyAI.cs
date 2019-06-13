using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class enemyAI : MonoBehaviour {

    [Header("Attributes")]
    [SerializeField] private float speed = 10f;
    //private int wavePointIndex = 0;
    [SerializeField] private int health = 100;
    [SerializeField] private int value = 50;
    [SerializeField] private int dmgCastel;

    [Header("Other")]
    [SerializeField] private GameObject deathEffect;
    

    [Header("NavMesh")]


    public NavMeshAgent Agent;
    public Transform EndDestination;
    public bool AgentHasPath = false;

    [SerializeField] private Transform start;

    private float dist;
    private navMeshManager navManager;
    private LineRenderer linerend;
    private NavMeshPath path;

    


    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        linerend = GetComponent<LineRenderer>();
        
    }
    void Start()
    {
        


        if (Agent == null)
        {
            Debug.Log("lägg till enemys navMeshAgent i" + gameObject.name);
        }else
        {
            Debug.Log("agent on mesh: " + Agent.isOnNavMesh + " agent is activeAndEnabled: " + Agent.isActiveAndEnabled);
            NavMesh.CalculatePath(Agent.transform.position, EndDestination.position, NavMesh.AllAreas, path);
            Debug.Log(path.status);
            Agent.SetPath(path);
            Debug.Log(Agent.hasPath);
            if (Agent.hasPath)
            {
                AgentHasPath = true;
            }
            Debug.Log("agent path Corners" + Agent.path.corners);

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

        linerend.positionCount = Agent.path.corners.Length;
        linerend.SetPositions(Agent.path.corners);
        linerend.enabled = true;

    }


    private void SetDestination()
    {
        if(EndDestination != null)
        {
            Vector3 endVector = EndDestination.transform.position;
            Agent.SetDestination(endVector);
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
