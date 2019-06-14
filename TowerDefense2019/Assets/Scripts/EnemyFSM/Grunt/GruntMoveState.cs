using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Enemy/Grunt/GruntMoveState")]
public class GruntMoveState : GruntBaseState
{
    public override void Enter()
    {
        Debug.Log("GruntMoveState.cs -> enter");

    }


    public override void HandleUpdate()
    {
        base.HandleUpdate();

        Owner.LineRend.positionCount = Owner.Agent.path.corners.Length;
        Owner.LineRend.SetPositions(Owner.Agent.path.corners);
        Owner.LineRend.enabled = true;

        if(Owner.Agent.pathStatus == NavMeshPathStatus.PathPartial)
        {
            Owner.Transition<GruntPartialPathState>();
        }
    }


}

