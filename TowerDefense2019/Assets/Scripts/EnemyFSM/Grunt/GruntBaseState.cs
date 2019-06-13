using UnityEngine;
using System;

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

    //public override void HandleUpdate()
    //{
        
    //}


}
