using UnityEngine;

namespace Gameplay
{
    public class JumpState : IMovementState
    {
        private readonly PlayerController _controller;
        private Character _character;
        private Coroutine _jumpCoroutine;
        private int _jumpsLeft;

        public JumpState(PlayerController playerController)
        {
            _controller = playerController;
            _jumpsLeft = _controller.MaxJumps - 1;
            //_character = playerController.GetComponent<Character>();
        }

        public void Enter()
        {
            _controller.RunJumpCoroutine();
            _controller.Character.OnLand += OnJumpEnd;
            
            /*
            if (_jumpCoroutine != null)
                _controller.StopCoroutine(_jumpCoroutine);
            _jumpCoroutine = _controller.StartCoroutine(_character.Jump());
            */       
        }
        

        public void HandleInput(Vector3 moveInput, bool jumpPressed)
        {
            var direction = moveInput * _controller.AirborneSpeedMultiplier;
            _controller.Character.SetDirection(direction);
            
            if (jumpPressed && _jumpsLeft > 0)
            {
                _controller.RunJumpCoroutine();
                _jumpsLeft--;
            }
        }

        public void PhysicsUpdate()
        {
        }

        public void OnCollisionEnter(Collision other)
        {
            foreach (var contact in other.contacts)
            {
                if (Vector3.Angle(contact.normal, Vector3.up) < 5)
                {
                    _controller.TransitionTo(new WalkState(_controller));
                    break;
                }
            }

        }

        public void Exit()
        {
            _controller.Character.OnLand -= OnJumpEnd;
        }

        private void OnJumpEnd()
        {
            _controller.TransitionTo(new WalkState(_controller));        
        }
        
    }
}
