using Leopotam.Ecs;
using System.Linq;
using UnityEngine;

public class WeaponReloadingSystem : IEcsRunSystem
{
    private Hud hud;
    private EcsFilter<EcsComponent.EquipWeaponMain, EcsComponent.Bag, EcsComponent.TryReloadEvent>.Exclude<EcsComponent.StateEndAmmo> filter;

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

            var clip = ItemData.Instance.Weapon[weapon.configIndex].Settings.sound.reloadClip;
            rnd = Random.Range(0, clip.Length);

            SoundController.PlayClipAtPosition(clip[rnd], weapon.shootPosition.position);

            if (entity.Has<EcsComponent.Player>())
            {
                hud.HudWeapon.ShowMagazine(weapon.currentInMagazine);
                hud.HudWeapon.ShowTotalAmmo(GetTotalAmmo(conteiners));
            }
            else
            {
                if (totalAmmo == 0)
                {
                    entity.Get<EcsComponent.StateEndAmmo>();
                }
            }
        }
    }

    private int GetTotalAmmo(ItemConteiner[] conteiners)
    {
        for (int i = 0; i < conteiners.Length; i++)
        {
            if(conteiners[i] is AmmoConteiner)
            {
                return (conteiners[i] as AmmoConteiner).GetCount();
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