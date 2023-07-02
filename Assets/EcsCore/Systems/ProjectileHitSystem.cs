using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class ProjectileHitSystem : IEcsRunSystem
{
    private StaticData config;
    private EcsFilter<EcsComponent.ProjectileHitEvent> filter;

    private Vector2 position;
    private Quaternion rotation;

    public void Run()
    {
        foreach (var i in filter)
        {
            position = filter.Get1(i).Position;
            rotation = filter.Get1(i).Rotation;
            Object.Instantiate(config.projectileSetting.hitEffectPrefab, position, rotation);
        }
    }

}