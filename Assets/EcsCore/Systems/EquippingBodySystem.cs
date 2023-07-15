using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class EquippingBodySystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingBodyEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            filter.GetEntity(i).Get<EcsComponent.EquipBody>();
        }
    }
}