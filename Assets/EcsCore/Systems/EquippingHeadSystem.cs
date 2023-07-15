using Leopotam.Ecs;
using UnityEngine;

internal class EquippingHeadSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingHeadEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            filter.GetEntity(i).Get<EcsComponent.EquipHead>();
        }
    }
}