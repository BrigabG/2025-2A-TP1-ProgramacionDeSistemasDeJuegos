using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gameplay
{
    public interface IMovementState 
    {
            void Enter();
            MovementIntent HandleInput(Vector3 moveInput, bool jumpPressed);
            MovementIntent PhysicsUpdate();
            MovementIntent OnCollisionEnter(Collision other);
            void Exit();
        
    }
}
