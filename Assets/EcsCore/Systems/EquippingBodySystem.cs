using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class EquippingBodySystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingBodyIntent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            entity.Get<EcsComponent.EquipBody>();
            entity.Del<EcsComponent.EquippingBodyIntent>();
        }
    }
}