﻿using Leopotam.Ecs;
using UnityEngine;

internal class WeaponShootSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData config;
    private Hud hud;
    private EcsFilter<EcsComponent.EquipWeapon, EcsComponent.ShootEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var entity = ref filter.GetEntity(i);
            ref var weapon = ref filter.Get1(i);
            ref var shootEvent = ref filter.Get2(i);

            if (weapon.currentInMagazine > 0)
            {
                weapon.currentInMagazine--;

                int rnd = Random.Range(0, config.weaponSettings.sound.shootClip.Length);
                SoundController.PlayClipAtPosition(config.weaponSettings.sound.shootClip[rnd], weapon.shootPosition.position, 0.2f);

                var projectileEntity = ecsWorld.NewEntity();
                ref var spawnProjectileEvent = ref projectileEntity.Get<EcsComponent.SpawnProjectileEvent>();
                spawnProjectileEvent.spawnPosition = weapon.shootPosition.position;
                spawnProjectileEvent.TargetPosition = shootEvent.TargetPosition;
                spawnProjectileEvent.power = weapon.weaponDamage;
                spawnProjectileEvent.origineEntity = entity;

                if (entity.Has<EcsComponent.Player>())
                {
                    hud.HudWeapon.ShowMagazine(weapon.currentInMagazine);
                }
            }
            else
            {
                int rnd = Random.Range(0, config.weaponSettings.sound.misfireClip.Length);
                SoundController.PlayClipAtPosition(config.weaponSettings.sound.misfireClip[rnd], weapon.shootPosition.position);

                entity.Get<EcsComponent.TryReloadEvent>();
            }
        }
    }
}