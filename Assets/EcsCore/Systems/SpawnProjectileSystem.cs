using Leopotam.Ecs;
using UnityEngine;

internal class SpawnProjectileSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData config;
    private EcsFilter<EcsComponent.SpawnProjectileEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var spawnProjectileEvent = ref filter.Get1(i);
            var spawnPosition = spawnProjectileEvent.spawnPosition;
            var projectileGO = Object.Instantiate(config.projectileSetting.prefab, spawnPosition, Quaternion.identity);

            var entity =  ecsWorld.NewEntity();

            entity.Get<EcsComponent.Projectile>().gameObject = projectileGO;

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