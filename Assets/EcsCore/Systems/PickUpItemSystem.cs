using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class PickUpItemSystem : IEcsRunSystem
{
    private StaticData config;
    private EcsFilter<EcsComponent.SceneItem, EcsComponent.PickUpSceneItemEvent, EcsComponent.Bag> filter;
    private Hud hud;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            ref var otherEntity = ref filter.Get2(i).otherEntity;
            var position = filter.Get1(i).itemGo.transform.position;
            ref var conteiners = ref filter.Get3(i).conteiners;

            if(otherEntity.Has<EcsComponent.Player>())
            {
                otherEntity.Get<EcsComponent.ShowUIBagEvent>().entity = otherEntity;
                hud.Inventory.ShowOtherBag(entity, conteiners);
            }
            else
            {
                //Логика переноса предметов между npc
            }
            int rnd = Random.Range(0, config.itemData.sound.inspectItem.Length);
            SoundController.PlayClipAtPosition(config.itemData.sound.inspectItem[rnd], position);

        }
    }

}