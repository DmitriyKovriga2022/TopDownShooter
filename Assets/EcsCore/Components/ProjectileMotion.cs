using UnityEngine;

namespace EcsComponent
{
    internal struct ProjectileMotion
    {
        public Transform Transform;
        public Vector2 Direction;
        public float MaxDistance;
        public float CurrentDistance;
        public float Speed;
    }
}