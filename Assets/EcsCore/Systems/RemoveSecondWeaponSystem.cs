using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class RemoveSecondWeaponSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.EquipWeaponSecond, EcsComponent.RemoveEqipSecondWeaponEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            Debug.Log("RemoveSecondWeaponSystem");
            filter.GetEntity(i).Del<EcsComponent.EquipWeaponSecond>();
        }
    }
}