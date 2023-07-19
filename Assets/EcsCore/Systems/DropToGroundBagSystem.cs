using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class DropToGroundBagSystem : IEcsRunSystem
{
    private StaticData config;
    private EcsFilter<EcsComponent.DropToGroundEvent, EcsComponent.Bag> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var worldPosition = filter.Get1(i).position;
            var index = filter.Get2(i).configIndex;
            var sceneItemGo = Object.Instantiate(config.sceneItemPrefab, worldPosition, Quaternion.identity);
            sceneItemGo.SetSprite(ItemData.Instance.Bag[index].Sprite);
            sceneItemGo.gameObject.layer = LayerMask.NameToLayer("Item");

            CircleCollider2D collider = sceneItemGo.gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 1;
            collider.isTrigger = true;

            var entity = filter.GetEntity(i);
            ref var item = ref entity.Get<EcsComponent.SceneItem>();
            var sceneItem = sceneItemGo.gameObject.GetComponent<UnityComponent.SceneItem>();
            sceneItem.entity = entity;
            item.itemGo = sceneItemGo;

        }
    }
}