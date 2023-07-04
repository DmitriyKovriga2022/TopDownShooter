using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class PickUpItemSystem : IEcsRunSystem
{
    private Hud hud;
    private EcsFilter<EcsComponent.Player, EcsComponent.PickUpItemEvent> playerFilter;
    private EcsFilter<EcsComponent.Weapon> weaponFilter;

    public void Run()
    {
        foreach (var i in playerFilter)
        {
            ref var playerEntity = ref playerFilter.GetEntity(i);

            foreach (var s in weaponFilter)
            {
                ref var weapon = ref weaponFilter.Get1(s);
                if (weapon.owner == playerEntity)
                {
                    weapon.totalAmmo += 10;
                    hud.HudWeapon.ShowAmmo(weapon.currentInMagazine);
                    hud.HudWeapon.ShowMagazin(weapon.totalAmmo);
                }
            }
        }
    }

}