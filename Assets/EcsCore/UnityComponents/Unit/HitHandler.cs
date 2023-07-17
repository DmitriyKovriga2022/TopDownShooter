using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityComponent
{
    public class HitHandler : MonoBehaviour
    {
        public event Action<EcsEntity> EventOnHit;
        public EcsEntity entity;

        public void OnHit(EcsEntity origineEntity)
        {
            EventOnHit?.Invoke(origineEntity);
        }
    }
}