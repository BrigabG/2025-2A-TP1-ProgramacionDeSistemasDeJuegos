using UnityEngine;

namespace Gameplay
{
    public static class Vector2Extensions
    {
        public static Vector3 ToHorizontalPlane(this Vector2 original)
            => new(original.x, 0, original.y);
    }
}