using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class SpawnSceneItemSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private EcsFilter<EcsComponent.SpawnSceneItemEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var spawnUnitEvent = ref filter.Get1(i);

            var entity = ecsWorld.NewEntity();
            ref var item = ref entity.Get<EcsComponent.SceneItem>();

            var gameObject = Object.Instantiate(staticData.sceneItemPrefab, spawnUnitEvent.position, Quaternion.identity);
            gameObject.gameObject.layer = LayerMask.NameToLayer("Item");
            CircleCollider2D collider = gameObject.gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 0.5f;
            collider.isTrigger = true;

            item.itemGo = gameObject;
            item.itemGo.entity = entity;

            ref var conteiners = ref filter.Get1(i).conteiners;
            ref var bag = ref entity.Get<EcsComponent.Bag>();
            bag.conteiners = conteiners;

        }
    }
}