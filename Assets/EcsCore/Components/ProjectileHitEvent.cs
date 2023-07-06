using UnityEngine;

namespace EcsComponent
{
    public struct ProjectileHitEvent
    {
        public Vector2 Position;
        public Quaternion Rotation;
        public Collider2D Collider;
    }
}