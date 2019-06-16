using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Enemy/Grunt/GruntSpawnState")]

public class GruntSpawnState : GruntBaseState
{

    public override void Enter()
    {
        Debug.Log("SpawnState.cs -> enter");

        Owner.Agent.SetPath(NavMeshManager.navMeshManagerInstance.GetPath());

        Debug.Log(Owner.Agent.pathStatus + " " + Owner.Agent.hasPath);
    }

    
    public override void HandleUpdate()
    {
        if (Owner.Agent.pathStatus == NavMeshPathStatus.PathComplete) 
        {

            Owner.HasSpawned = true;
            Owner.Transition<GruntMoveState>();
        }else if(Owner.Agent.pathStatus == NavMeshPathStatus.PathPartial)
        {
            Owner.HasSpawned = true;
            Owner.Transition<GruntPartialPathState>();
        }else if( Owner.Agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            Enter();
        }

    }

}
