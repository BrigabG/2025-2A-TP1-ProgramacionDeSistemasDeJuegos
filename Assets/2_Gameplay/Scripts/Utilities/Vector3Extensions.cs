using UnityEngine;

namespace Gameplay
{
    public static class Vector3Extensions
    {
        public static Vector3 IgnoreY(this Vector3 original)
            => new(original.x, 0, original.z);
    }
}