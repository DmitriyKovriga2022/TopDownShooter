using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class EquippingAmmoSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private Hud hud;
    private EcsFilter<EcsComponent.EquipWeaponMain, EcsComponent.EquippingAmmoIntent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            Debug.Log("Equip ammo in progress");
            //var entity = filter.GetEntity(i);
            //ref var weaponEntity = ref filter.Get1(i).weapon;
            //ref var weapon = ref weaponEntity.Get<EcsComponent.Weapon>();
            //ref var ammoCaunt = ref filter.Get2(i).Count;
            //weapon.totalAmmo += ammoCaunt;

            //if (entity.Has<EcsComponent.Player>())
            //{
            //    hud.HudWeapon.ShowMagazine(weapon.currentInMagazine);
            //    hud.HudWeapon.ShowTotalAmmo(weapon.totalAmmo);
            //}

            //entity.Del<EcsComponent.EquippingAmmoIntent>();
        }
    }
}