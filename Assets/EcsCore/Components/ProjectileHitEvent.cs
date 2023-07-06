using UnityEngine;

namespace EcsComponent
{
    public struct ProjectileHitEvent
    {
        public float power;
        public Vector2 Position;
        public Quaternion Rotation;
        public Collider2D Collider;
    }
}