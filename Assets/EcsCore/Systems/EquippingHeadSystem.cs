using Leopotam.Ecs;
using UnityEngine;

internal class EquippingHeadSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingHeadIntent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            entity.Get<EcsComponent.EquipHead>();
            entity.Del<EcsComponent.EquippingHeadIntent>();
        }
    }
}