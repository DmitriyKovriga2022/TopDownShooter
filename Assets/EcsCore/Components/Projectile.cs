using UnityEngine;

namespace EcsComponent
{
    internal struct Projectile
    {
        public IGameObject gameObject;
        public Vector2 TargetPosition;
    }
}