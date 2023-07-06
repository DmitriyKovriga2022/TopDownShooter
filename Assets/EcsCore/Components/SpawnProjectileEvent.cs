using UnityEngine;

namespace EcsComponent
{
    internal struct SpawnProjectileEvent
    {
        public Vector2 spawnPosition;
        public Vector2 TargetPosition;
        public float power;
    }
}