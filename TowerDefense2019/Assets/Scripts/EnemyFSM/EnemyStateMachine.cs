﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EnemyStateMachine : MonoBehaviour
{
    // Attributes
    [SerializeField] private EnemyState[] states;

    private Dictionary<Type, EnemyState> stateDictionary = new Dictionary<Type, EnemyState>();
    protected EnemyState currentState;

    // Methods
    protected virtual void Awake()
    {
        foreach (EnemyState state in states)
        {
            EnemyState instance = Instantiate(state);
            instance.Initialize(this);
            stateDictionary.Add(instance.GetType(), instance);
            if (currentState == null)
                currentState = instance;
        }
        currentState.Enter();
    }

    public void Transition<T>() where T : EnemyState
    {
        currentState.Exit();
        currentState = stateDictionary[typeof(T)];
        currentState.Enter();
    }

    private void Update()
    {
        currentState.HandleUpdate();
    }

    private void FixedUpdate()
    {
        currentState.HandelFixedUpdate();
    }

}
