﻿using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class ShowEquipMenuSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Unit, EcsComponent.ShowUIEquipEvent> filter;
    private Hud hud;

    public void Run()
    {
        foreach (var i in filter)
        {
            var selfEntity = filter.GetEntity(i);
            var position = filter.Get1(i).UnitGO.transform.position;
            selfEntity.Get<EcsComponent.ShowUIBagEvent>().entity = selfEntity;
            hud.Inventory.ShowEquipPanel(selfEntity);

            int rnd = Random.Range(0, ItemData.Instance.sound.inspectItem.Length);
            SoundController.PlayClipAtPosition(ItemData.Instance.sound.inspectItem[rnd], position);
        }
    }
}