using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class EquippingSecondWeaponSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingWeaponSecondEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            filter.GetEntity(i).Get<EcsComponent.EquipWeaponSecond>();
        }
    }
}