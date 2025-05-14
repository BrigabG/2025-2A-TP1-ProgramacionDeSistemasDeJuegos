using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [Serializable]
    public class MovementStateMachine
    {
        public IMovementState CurrentState { get; private set; }
        public event Action<IMovementState> stateChanged;
        
        public void Initialize(IMovementState state)
        {
            CurrentState = state;
            state.Enter();
            
            stateChanged?.Invoke(state);
        }
        
        public void TransitionTo(IMovementState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();

            stateChanged?.Invoke(nextState);
        }
        
        public void HandleInput(Vector3 moveInput, bool jumpPressed) => CurrentState.HandleInput(moveInput, jumpPressed);
        
        public void PhysicsUpdate() => CurrentState.PhysicsUpdate();
        
        public void OnCollisionEnter(Collision other) => CurrentState.OnCollisionEnter(other);
    }
}
