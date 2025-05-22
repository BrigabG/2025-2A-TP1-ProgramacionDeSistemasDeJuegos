using UnityEngine;

namespace Gameplay
{
    public class WalkState : IMovementState
    {
        private readonly PlayerController _controller;
        private Vector3 _movement;

        public WalkState(PlayerController controller)
        {
            _controller = controller;
        }

        public void Enter()
        {
            Debug.Log("Entrando en Walk State");
            _movement = Vector3.zero;
        }

        public MovementIntent HandleInput(Vector3 moveInput, bool jumpPressed)
        {
            _movement = moveInput;
            if (jumpPressed)
            {
                return new MovementIntent(MovementIntent.IntentType.WantToJump);
            }
            return MovementIntent.NoneIntent;
        }

        public MovementIntent PhysicsUpdate()
        {
            _controller.Character.SetDirection(_movement);
            return MovementIntent.NoneIntent;
        }

        public MovementIntent OnCollisionEnter(Collision other)
        {
            return MovementIntent.NoneIntent;
        }

        public void Exit(){}
    
    
    }
}
