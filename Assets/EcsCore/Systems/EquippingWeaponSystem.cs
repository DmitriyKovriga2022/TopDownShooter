using Leopotam.Ecs;
using UnityEngine;

internal class EquippingWeaponSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private Hud hud;
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingWeaponEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            var unitComponent = filter.Get1(i);
            ref var weapon = ref entity.Get<EcsComponent.EquipWeapon>();
            var setting = staticData.weaponSettings;
            var weaponGO = Object.Instantiate(setting.weaponPrefab, unitComponent.UnitGO.weaponHolder);
            weaponGO.gameObject.AddComponent<UnityComponent.LookAtPosition>();
            weapon.WeaponGo = weaponGO;
            weapon.totalAmmo = setting.totalAmmo;
            weapon.weaponDamage = setting.weaponDamage;
            weapon.currentInMagazine = setting.currentInMagazine;
            weapon.maxInMagazine = setting.maxInMagazine;
            weapon.shootPosition = weaponGO.PointShoot;

            if (unitComponent.owner.Has<EcsComponent.Player>())
            {
                hud.HudWeapon.ShowAmmo(weapon.currentInMagazine);
                hud.HudWeapon.ShowMagazin(weapon.totalAmmo);
            }
            else
            {
                weaponGO.RenderTransform.gameObject.layer = 7;
            }

            //ref var hasWeapon = ref entity.Get<EcsComponent.HasWeapon>();
            //var setting = staticData.weaponSettings;
            //var weaponGO = Object.Instantiate(setting.weaponPrefab, unitComponent.UnitGO.weaponHolder);
            //var weaponEntity = ecsWorld.NewEntity();
            //ref var weapon = ref weaponEntity.Get<EcsComponent.Weapon>();
            //weapon.owner = entity;
            //weapon.totalAmmo = setting.totalAmmo;
            //weapon.weaponDamage = setting.weaponDamage;
            //weapon.currentInMagazine = setting.currentInMagazine;
            //weapon.maxInMagazine = setting.maxInMagazine;
            //weapon.shootPosition = weaponGO.PointShoot;
            //weapon.weaponGo = weaponGO;
            //hasWeapon.weapon = weaponEntity;
            //weaponGO.entity = weaponEntity;

            //weaponGO.gameObject.AddComponent<UnityComponent.LookAtPosition>();

            //if (unitComponent.owner.Has<EcsComponent.Player>())
            //{
            //    hud.HudWeapon.ShowAmmo(weapon.currentInMagazine);
            //    hud.HudWeapon.ShowMagazin(weapon.totalAmmo);
            //}
            //else
            //{
            //    weaponGO.RenderTransform.gameObject.layer = 7;
            //}


        }
    }
}