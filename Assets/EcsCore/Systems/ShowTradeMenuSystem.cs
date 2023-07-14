using Leopotam.Ecs;
using UnityEngine;

public class ShowTradeMenuSystem : IEcsRunSystem
{
    private StaticData config;
    private EcsFilter<EcsComponent.Unit, EcsComponent.ShowTradeMenuEvent> filter;
    private Hud hud;

    public void Run()
    {
        foreach (var i in filter)
        {
            var selfEntity = filter.GetEntity(i);
            ref var otherEntity = ref filter.Get2(i).otherEntity;
            var position = filter.Get1(i).UnitGO.transform.position;

            if (otherEntity.Has<EcsComponent.Player>())
            {
                otherEntity.Get<EcsComponent.ShowUIBagEvent>().entity = otherEntity;
                hud.Inventory.ShowTradeBag(selfEntity, otherEntity);
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