using UnityEngine;

namespace Gameplay
{
    public class JumpState : IMovementState
    {
        private readonly PlayerController _controller;
        private int _jumpsLeft;

        public JumpState(PlayerController playerController)
        {
            _controller = playerController;
            _jumpsLeft = _controller.Settings.maxJumps - 1;
        }

        public void Enter()
        {
            _controller.RunJumpCoroutine();
        }
        

        public MovementIntent HandleInput(Vector3 moveInput, bool jumpPressed)
        {
            var direction = moveInput * _controller.Settings.airborneSpeedMultiplier;
            _controller.Character.SetDirection(direction);
            
            if (jumpPressed && _jumpsLeft > 0)
            {
                _controller.RunJumpCoroutine();
                _jumpsLeft--;
            }
            return MovementIntent.NoneIntent;
        }

        public MovementIntent PhysicsUpdate() => MovementIntent.NoneIntent;

        public MovementIntent OnCollisionEnter(Collision other)
        {
            foreach (var contact in other.contacts)
            {
                if (Vector3.Angle(contact.normal, Vector3.up) < 5)
                {
                    Debug.Log("Landed");
                    return new MovementIntent(MovementIntent.IntentType.Landed);
                }
            }
            Debug.Log("No landed");
            return MovementIntent.NoneIntent;
        }

        public void Exit(){}
    }
}
