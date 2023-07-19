using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class EquippingSecondWeaponSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingWeaponSecondIntent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            var configIndex = filter.Get2(i).configIndex;
            filter.GetEntity(i).Get<EcsComponent.EquipWeaponSecond>().configIndex = configIndex;
            entity.Del<EcsComponent.EquippingWeaponSecondIntent>();
        }
    }
}