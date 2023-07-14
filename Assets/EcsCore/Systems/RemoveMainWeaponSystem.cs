using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class RemoveMainWeaponSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.EquipWeapon, EcsComponent.RemoveEqipMainWeaponEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            Debug.Log("RemoveMainWeaponSystem");
            filter.Get1(i).WeaponGo.DestroySelf();
            filter.GetEntity(i).Del<EcsComponent.EquipWeapon>();
        }
    }
}