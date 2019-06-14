using UnityEngine;
using System;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Enemy/Grunt/GruntBaseState")]
public class GruntBaseState : EnemyState
{



    protected Grunt Owner;



    public override void Initialize(EnemyStateMachine Owner)
    {
        this.Owner = (Grunt)Owner;
    }


    public override void Enter()
    {
        Debug.Log("GruntBaseState.cs -> Enter");
    }

    public override void HandleUpdate()
    {
        if (Owner.HasSpawned == false)
        {
            Owner.Transition<GruntSpawnState>();
        }

        if (Owner.Agent.path.status == UnityEngine.AI.NavMeshPathStatus.PathPartial)
        {

        }
    }


    //public override void HandleUpdate()
    //{

    //}


}
