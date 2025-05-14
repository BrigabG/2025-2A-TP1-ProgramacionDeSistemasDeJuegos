using UnityEngine;

namespace Gameplay
{
    public class WalkState : IMovementState
    {
        private readonly PlayerController _controller;
        private Vector3 _movement;
        //private Character _character;

        public WalkState(PlayerController controller)
        {
            _controller = controller;
            //_character = playerController.GetComponent<Character>();
        }

        public void Enter()
        {
            _movement = Vector3.zero;
        }

        public void HandleInput(Vector3 moveInput, bool jumpPressed)
        {
            _movement = moveInput;
            if (jumpPressed)
            {
                _controller.TransitionTo(new JumpState(_controller));
            }
        }

        public void PhysicsUpdate()
        {
            _controller.Character.SetDirection(_movement);
        }

        public void OnCollisionEnter(Collision other) { }

        public void Exit(){}
    
    
    }
}
