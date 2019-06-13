using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Grunt : EnemyStateMachine
{


    [Header("Attributes")]
    [SerializeField] public float speed = 10f;
    [SerializeField] public int health = 100;
    [SerializeField] public int value = 50;
    [SerializeField] public int dmgCastel;

    
    [Header("NavMesh")]
    [SerializeField] public NavMeshAgent Agent;
    [SerializeField] public Transform start;
    [SerializeField] public Transform EndDestination;
    [SerializeField] public bool AgentHasPath = false;
    //[SerializeField] public NavMeshPath path;


    [Header("VFX")]
    [SerializeField] public GameObject deathEffect;


    [Header("Other")]
    [HideInInspector] public float dist;
    [HideInInspector] public LineRenderer LineRend;


    protected override void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        LineRend = GetComponent<LineRenderer>();
        //path = new NavMeshPath();

        base.Awake();
        Debug.Log("Grunt.cs " + currentState.ToString());

    }


    
}

