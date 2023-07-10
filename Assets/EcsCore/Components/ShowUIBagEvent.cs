using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace EcsComponent
{
    public struct ShowUIBagEvent
    {
        /// <summary>
        /// Сущщность, которая вызывает необходимость показать ui сумки
        /// </summary>
        public EcsEntity entity;
    }
}