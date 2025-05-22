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
        public event Action<IMovementState> stateChanged; // For future use
        private readonly PlayerController _controller;

        private readonly Dictionary<(Type, MovementIntent.IntentType), Func<IMovementState>> _transitions;

        public MovementStateMachine(PlayerController controller)
        {
            _controller = controller;
            _transitions = new Dictionary<(Type, MovementIntent.IntentType), Func<IMovementState>>
            {
                { (typeof(WalkState), MovementIntent.IntentType.WantToJump), () => new JumpState(_controller) },
                { (typeof(JumpState), MovementIntent.IntentType.Landed), () => new WalkState(_controller) }
                // Can add more transitions here
            };
        }

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
        
        private void HandleIntent(MovementIntent intent)
        {
            if (intent == null || intent.Type == MovementIntent.IntentType.None)
                return;

            var key = (CurrentState.GetType(), intent.Type);
            if (_transitions.TryGetValue(key, out var nextStateFactory))
            {
                TransitionTo(nextStateFactory());
            }
        }

        public void HandleInput(Vector3 moveInput, bool jumpPressed)
        {
            var intent = CurrentState.HandleInput(moveInput, jumpPressed);
            HandleIntent(intent);
        }
            

        public void PhysicsUpdate()
        {
            var intent = CurrentState.PhysicsUpdate();
            HandleIntent(intent);
        }

        public void OnCollisionEnter(Collision other)
        {
            var intent = CurrentState.OnCollisionEnter(other);
            HandleIntent(intent);
        }
    }
}
