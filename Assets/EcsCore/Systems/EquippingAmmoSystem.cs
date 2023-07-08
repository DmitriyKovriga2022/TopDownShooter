using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class EquippingAmmoSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private Hud hud;
    private EcsFilter<EcsComponent.HasWeapon, EcsComponent.EquippingAmmoEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            ref var weaponEntity = ref filter.Get1(i).weapon;
            ref var weapon = ref weaponEntity.Get<EcsComponent.Weapon>();
            ref var ammoCaunt = ref filter.Get2(i).Count;
            weapon.totalAmmo += ammoCaunt;

            if (entity.Has<EcsComponent.Player>())
            {
                hud.HudWeapon.ShowAmmo(weapon.currentInMagazine);
                hud.HudWeapon.ShowMagazin(weapon.totalAmmo);
            }
        }
    }
}