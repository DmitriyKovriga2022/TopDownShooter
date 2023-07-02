using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class ItemCollisionSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.SceneItem, EcsComponent.ItemCollisionEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            filter.Get2(i).otherEntity.Get<EcsComponent.PickUpItemEvent>();
            filter.Get1(i).itemGo.DestroySelf();
            filter.GetEntity(i).Destroy();
        }
    }
}