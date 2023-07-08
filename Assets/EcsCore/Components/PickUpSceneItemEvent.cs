using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace EcsComponent
{
    public struct PickUpSceneItemEvent
    {
        public EcsEntity otherEntity;
        public Vector2 worldPosition;
        public ItemConteiner conteiner;
    }
}