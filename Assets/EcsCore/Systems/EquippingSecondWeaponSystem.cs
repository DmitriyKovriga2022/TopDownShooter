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
            filter.GetEntity(i).Get<EcsComponent.EquipWeaponSecond>();
            entity.Del<EcsComponent.EquippingWeaponSecondIntent>();
        }
    }
}