using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyState : ScriptableObject
{
    public virtual void Initialize(EnemyStateMachine owner) { }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void HandleUpdate() { }
    public virtual void HandelFixedUpdate() { }
}
