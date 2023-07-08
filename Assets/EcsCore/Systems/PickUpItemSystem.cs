using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class PickUpItemSystem : IEcsRunSystem
{
    private StaticData config;
    private EcsFilter<EcsComponent.PickUpSceneItemEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var itemEntity = filter.GetEntity(i);
            ref var otherEntity = ref filter.Get1(i).otherEntity;
            ref var position = ref filter.Get1(i).worldPosition;

            ref var conteiner = ref filter.Get1(i).conteiner;

            if (conteiner is AmmoConteiner)
            {
                otherEntity.Get<EcsComponent.EquippingAmmoEvent>().Count = (conteiner as AmmoConteiner).GetContent();
            }

            if (conteiner is MedKitConteiner)
            {
               otherEntity.Get<EcsComponent.ApplyMedKitEvent>().Count = (conteiner as MedKitConteiner).GetContent();
            }

            itemEntity.Get<EcsComponent.DestroyEntityEvent>();

            int rnd = Random.Range(0, config.itemData.sound.inspectItem.Length);
            SoundController.PlayClipAtPosition(config.itemData.sound.inspectItem[rnd], position);

        }
    }

}