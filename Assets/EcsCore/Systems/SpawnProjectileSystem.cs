using Leopotam.Ecs;
using UnityEngine;

internal class SpawnProjectileSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData config;
    private EcsFilter<EcsComponent.SpawnProjectileEvent> filter;

    private float power;
    private Vector2 spawnPosition;
    private UnityComponent.Projectile projectileGO;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var spawnProjectileEvent = ref filter.Get1(i);
            power = spawnProjectileEvent.power;
            spawnPosition = spawnProjectileEvent.spawnPosition;
            projectileGO = Object.Instantiate(config.projectileSetting.prefab, spawnPosition, Quaternion.identity);

            var entity =  ecsWorld.NewEntity();
            ref var projectile = ref entity.Get<EcsComponent.Projectile>();
            projectile.gameObject = projectileGO;
            projectile.power = power;

            ref var motionComponent = ref entity.Get<EcsComponent.ProjectileMotion>();
            motionComponent.Transform = projectileGO.Transform;
            motionComponent.Speed = projectileGO.Speed;
            motionComponent.MaxDistance = (spawnProjectileEvent.TargetPosition - spawnPosition).magnitude;
            motionComponent.CurrentDistance = 0;
            motionComponent.Direction = (spawnProjectileEvent.TargetPosition - spawnPosition).normalized;

            if (config.projectileSetting.LiveTime <= 0)
            {
                Debug.LogWarning("LiveTime in Config is 0");
            }

            entity.Get<EcsComponent.LiveTime>().EndTime = Time.time + config.projectileSetting.LiveTime;
            entity.Get<EcsComponent.LiveTime>().gameObject = projectileGO;
        }
    }
}