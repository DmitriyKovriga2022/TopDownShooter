using Leopotam.Ecs;
using UnityEngine;

namespace EcsComponent
{
    internal struct SpawnProjectileEvent
    {
        /// <summary>
        /// Позиция, где нужно создать снаряд
        /// </summary>
        public Vector2 spawnPosition;
        /// <summary>
        /// Позиция, куда прилетит снаряд
        /// </summary>
        public Vector2 TargetPosition;
        /// <summary>
        /// Сущность, создавшая снаряд
        /// </summary>
        public EcsEntity origineEntity;
        /// <summary>
        /// Количество здоровья, которое снимает снаряд
        /// </summary>
        public float power;
    }
}