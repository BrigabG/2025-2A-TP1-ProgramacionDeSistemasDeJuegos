using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    [RequireComponent(typeof(Character))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionReference moveInput;
        [SerializeField] private InputActionReference jumpInput;
        [SerializeField] private MovementSettings settings;

        
        
        private Character _character;
        private MovementStateMachine _movementStateMachine;
        private Vector3 _moveValue;
        private bool _jumpPressed;
        private Coroutine _jumpCoroutine;

        public Character Character => _character;
        
        public MovementSettings Settings => settings;
        

        private void Awake()
        {
            _character = GetComponent<Character>();
            _movementStateMachine = new MovementStateMachine();
            _movementStateMachine.Initialize(new WalkState(this));

        }

        private void OnEnable()
        {
            if (moveInput?.action != null)
            {
                moveInput.action.started += HandleMoveInput;
                moveInput.action.performed += HandleMoveInput;
                moveInput.action.canceled += HandleMoveInput;
            }
            if (jumpInput?.action != null)
                jumpInput.action.performed += HandleJumpInput;
        }
        private void OnDisable()
        {
            if (moveInput?.action != null)
            {
                moveInput.action.performed -= HandleMoveInput;
                moveInput.action.canceled -= HandleMoveInput;
            }
            if (jumpInput?.action != null)
                jumpInput.action.performed -= HandleJumpInput;
        }

        private void HandleMoveInput(InputAction.CallbackContext ctx)
        {
            _moveValue = ctx.ReadValue<Vector2>().ToHorizontalPlane();
        }

        private void HandleJumpInput(InputAction.CallbackContext ctx)
        {
            _jumpPressed = ctx.performed;
        }

        private void Update()
        {
            _movementStateMachine.HandleInput(_moveValue, _jumpPressed);
            _jumpPressed = false;
        }
        
        private void FixedUpdate()
        {
            _movementStateMachine.PhysicsUpdate();
        }

        public void RunJumpCoroutine()
        {
            if (_jumpCoroutine != null)
                StopCoroutine(_jumpCoroutine);
            _jumpCoroutine = StartCoroutine(_character.Jump());
        }

        private void OnCollisionEnter(Collision other)
        {
            _movementStateMachine.OnCollisionEnter(other);
        }

        public void TransitionTo(IMovementState nextState) => _movementStateMachine.TransitionTo(nextState);
    }
}