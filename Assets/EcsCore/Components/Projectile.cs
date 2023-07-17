using Leopotam.Ecs;
using UnityEngine;

namespace EcsComponent
{
    public struct Projectile
    {
        /// <summary>
        /// GameObject этого снаряда
        /// </summary>
        public IGameObject gameObject;
        /// <summary>
        /// Сущность, корорая создала этот сняряд
        /// </summary>
        public EcsEntity originEntity;
        /// <summary>
        /// Сколько здоровья снимает этот снаряд
        /// </summary>
        public float power;
    }
}