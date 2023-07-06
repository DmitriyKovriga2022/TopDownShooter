﻿using Leopotam.Ecs;
using UnityEngine;

internal class WeaponReloadingSystem : IEcsRunSystem
{
    private StaticData config;
    private Hud hud;
    private EcsFilter<EcsComponent.TryReloadEvent, EcsComponent.Weapon> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var weapon = ref filter.Get2(i);

            var needAmmo = weapon.maxInMagazine - weapon.currentInMagazine;

            weapon.currentInMagazine = (weapon.totalAmmo >= needAmmo)
                ? weapon.maxInMagazine
                : weapon.currentInMagazine + weapon.totalAmmo;

            weapon.totalAmmo -= needAmmo;
            weapon.totalAmmo = weapon.totalAmmo < 0 ? 0 : weapon.totalAmmo;

            int rnd = Random.Range(0, config.weaponSettings.sound.reloadClip.Length);
            SoundController.PlayClipAtPosition(config.weaponSettings.sound.reloadClip[rnd], weapon.shootPosition.position);

            hud.HudWeapon.ShowAmmo(weapon.currentInMagazine);
            hud.HudWeapon.ShowMagazin(weapon.totalAmmo);
        }
    }
}