using Leopotam.Ecs;
using UnityEngine;

namespace EcsComponent
{
    internal struct Unit
    {
        public EcsEntity owner;
        public UnityComponent.Unit UnitGO;
    }
}