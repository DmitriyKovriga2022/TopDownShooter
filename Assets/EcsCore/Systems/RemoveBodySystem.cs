using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class RemoveBodySystem : IEcsRunSystem
    {
        private EcsFilter<EcsComponent.EquipBody, EcsComponent.RemoveEqipBodyEvent> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                Debug.Log("RemoveBodySystem");
                filter.GetEntity(i).Del<EcsComponent.EquipBody>();
            }
        }
    }