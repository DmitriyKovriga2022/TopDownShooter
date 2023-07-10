using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class ShowBagUISystem : IEcsRunSystem
{
    private Hud hud;
    private EcsFilter<EcsComponent.ShowUIBagEvent, EcsComponent.Bag> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            ref var containers = ref filter.Get2(i).conteiners;
            var otherEntity = filter.Get1(i).entity;
            hud.Inventory.ShowSelfBag(entity, containers);
        }
    }
}