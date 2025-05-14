using UnityEngine;

namespace Gameplay
{
    public interface IMovementState 
    {
            void Enter();
            void HandleInput(Vector3 moveInput, bool jumpPressed);
            void PhysicsUpdate();
            void OnCollisionEnter(Collision other);
            void Exit();
        
    }
}
