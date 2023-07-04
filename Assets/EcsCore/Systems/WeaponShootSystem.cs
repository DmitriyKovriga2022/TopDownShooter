using Leopotam.Ecs;
using UnityEngine;

internal class WeaponShootSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private Hud hud;
    private EcsFilter<EcsComponent.Weapon, EcsComponent.ShootEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var weapon = ref filter.Get1(i);
            ref var shootEvent = ref filter.Get2(i);
            ref var entity = ref filter.GetEntity(i);

            if (weapon.currentInMagazine > 0)
            {
                weapon.currentInMagazine--;
                ref var spawnProjectileEvent = ref ecsWorld.NewEntity().Get<EcsComponent.SpawnProjectileEvent>();
                spawnProjectileEvent.spawnPosition = weapon.shootPosition.position;
                spawnProjectileEvent.TargetPosition = shootEvent.TargetPosition;

                hud.HudWeapon.ShowAmmo(weapon.currentInMagazine);
            }
            else
            {
                entity.Get<EcsComponent.TryReloadEvent>();
            }
        }
    }
}