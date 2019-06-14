﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Grunt : EnemyStateMachine
{
    public bool HasSpawned = false;



    
    [Header("NavMesh")]
    [SerializeField] public NavMeshAgent Agent;
    [SerializeField] public Transform start;
    [SerializeField] public Transform EndDestination;
    //[SerializeField] public bool AgentHasPath = false;
    //[SerializeField] public NavMeshPath path;





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

