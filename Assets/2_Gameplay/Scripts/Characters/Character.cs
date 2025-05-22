using System;
using System.Collections;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private MovementSettings settings;
        
        private Vector3 _direction = Vector3.zero;
        private Rigidbody _rigidbody;
        public event Action OnLand;

        private void Awake()
            => _rigidbody = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            var scaledDirection = _direction * settings.acceleration;
            if (_rigidbody.linearVelocity.IgnoreY().magnitude < settings.speed)
                _rigidbody.AddForce(scaledDirection, ForceMode.Force);
        }

        public void SetDirection(Vector3 direction) => _direction = direction;

        public IEnumerator Jump()
        {
            yield return new WaitForFixedUpdate();
            _rigidbody.AddForce(Vector3.up * settings.jumpForce, ForceMode.Impulse);
        }
    }
}