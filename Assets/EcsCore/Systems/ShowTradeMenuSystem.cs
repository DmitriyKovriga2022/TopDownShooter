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

            if(otherEntity.IsNull())
            {
                Debug.LogError("Other Entity is null");
                continue;
            }

            if (otherEntity.Has<EcsComponent.Player>())
            {
                otherEntity.Get<EcsComponent.ShowUIBagEvent>().entity = otherEntity;
                hud.Inventory.ShowTradeBag(selfEntity, otherEntity);
            }
            else
            {
                //Логика переноса предметов между npc
            }
            int rnd = Random.Range(0, ItemData.Instance.sound.inspectItem.Length);
            SoundController.PlayClipAtPosition(ItemData.Instance.sound.inspectItem[rnd], position);

        }
    }
}