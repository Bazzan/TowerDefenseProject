using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Enemy/Grunt/GruntSpawnState")]

public class GruntSpawnState : GruntBaseState
{

    public override void Enter()
    {
        //Debug.Log("SpawnState.cs -> enter");
        //Debug.Log(Owner.Agent.pathStatus );
        Owner.Agent.SetPath(navMeshManager.GetPath());

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
