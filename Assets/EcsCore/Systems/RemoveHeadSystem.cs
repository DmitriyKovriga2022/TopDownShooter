using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class RemoveHeadSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.EquipHead, EcsComponent.RemoveEqipHeadEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            Debug.Log("RemoveHeadSystem");
            filter.GetEntity(i).Del<EcsComponent.EquipHead>();
        }
    }
}