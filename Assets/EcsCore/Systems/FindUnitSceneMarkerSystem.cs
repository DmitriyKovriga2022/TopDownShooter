﻿using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class FindUnitSceneMarkerSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;

    public void Run()
    {
        foreach (var item in GameObject.FindObjectsOfType<UnityComponent.UnitSceneMarker>())
        {
            var entity = ecsWorld.NewEntity();
            ref var component = ref entity.Get<EcsComponent.SpawnUnitEvent>();
            component.position = item.transform.position;
            component.unitType = item.unitType;
            item.DestroySelf();
        }
    }
}