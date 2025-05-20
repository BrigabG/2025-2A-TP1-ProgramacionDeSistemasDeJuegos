using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "MovementSettings", menuName = "Config/MovementSettings")]
    public class MovementSettings : ScriptableObject
    {
        [Header("Character Movement")]
        public float acceleration = 10f;
        public float speed = 3f;
    
        [Header("Jumping")]
        public float jumpForce = 10f;
        public int   maxJumps = 2;
        [Tooltip("Airbone speed multiplier")]
        public float airborneSpeedMultiplier = 0.5f;
    }
}
