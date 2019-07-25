using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Enemy/Grunt/GruntPartialPathState")]

public class GruntPartialPathState : GruntBaseState
{
    private float timeToCheckPath = 1f;


    public override void Enter()
    {
        //Debug.Log(" GruntPartialPath.cs -> enter");
    }


    public override void HandleUpdate()
    {
        base.HandleUpdate();

        if(timeToCheckPath <= 0)
        {
            Owner.Agent.SetPath(NavMeshManager.navMeshManagerInstance.GetPath());
            timeToCheckPath = 1f;
        }
        timeToCheckPath -= Time.deltaTime;

        if(Owner.Agent.pathStatus == NavMeshPathStatus.PathPartial)
        {
            //Owner.Agent.isStopped = true;

            //Owner.Agent.

        }


        if(Owner.Agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            Owner.Agent.isStopped = false;
            Owner.Transition<GruntMoveState>();
        }
    }

}
