using Leopotam.Ecs;
using System.Linq;
using UnityEngine;

public class WeaponReloadingSystem : IEcsRunSystem
{
    private StaticData config;
    private Hud hud;
    private EcsFilter<EcsComponent.EquipWeapon, EcsComponent.Bag, EcsComponent.TryReloadEvent> filter;

    EcsEntity entity;
    int rnd;
    int needAmmo;

    public void Run()
    {
        foreach (var i in filter)
        {
            entity = filter.GetEntity(i);
            ref var weapon = ref filter.Get1(i);
            needAmmo = weapon.maxInMagazine - weapon.currentInMagazine;

            ref var conteiners = ref filter.Get2(i).conteiners;
            var totalAmmo = GetTotalAmmo(conteiners);

            weapon.currentInMagazine = (totalAmmo >= needAmmo)
                ? weapon.maxInMagazine
                : weapon.currentInMagazine + totalAmmo;

            totalAmmo -= needAmmo;
            totalAmmo = Mathf.Clamp(totalAmmo, 0, int.MaxValue);

            SetTotalAmmo(totalAmmo, conteiners);

            rnd = Random.Range(0, config.weaponSettings.sound.reloadClip.Length);
            SoundController.PlayClipAtPosition(config.weaponSettings.sound.reloadClip[rnd], weapon.shootPosition.position);

            if (entity.Has<EcsComponent.Player>())
            {
                hud.HudWeapon.ShowMagazine(weapon.currentInMagazine);
                hud.HudWeapon.ShowTotalAmmo(GetTotalAmmo(conteiners));
            }
        }
    }

    private int GetTotalAmmo(ItemConteiner[] conteiners)
    {
        for (int i = 0; i < conteiners.Length; i++)
        {
            if(conteiners[i] is AmmoConteiner)
            {
                return (conteiners[i] as AmmoConteiner).GetContent();
            }
        }

        return 0;
    }

    private void SetTotalAmmo(int ammo, ItemConteiner[] conteiners)
    {
        for (int i = 0; i < conteiners.Length; i++)
        {
            if (conteiners[i] is AmmoConteiner)
            {
                (conteiners[i] as AmmoConteiner).SeContentValue(ammo);
                break;
            }
        }
    }

}