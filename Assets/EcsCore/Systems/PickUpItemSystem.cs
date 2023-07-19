using Leopotam.Ecs;
using UnityEngine;

public class PickUpItemSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.SceneItem, EcsComponent.PickUpSceneItemEvent> filter;
    private Hud hud;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            ref var otherEntity = ref filter.Get2(i).otherEntity;
            var position = filter.Get1(i).itemGo.transform.position;

            if(otherEntity.Has<EcsComponent.Player>())
            {
                otherEntity.Get<EcsComponent.ShowUIBagEvent>().entity = otherEntity;
                hud.Inventory.ShowOtherBag(entity);
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