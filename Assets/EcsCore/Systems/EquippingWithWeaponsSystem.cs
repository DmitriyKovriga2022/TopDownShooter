using Leopotam.Ecs;
using UnityEngine;

internal class EquippingWithWeaponsSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private Hud hud;
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingWithWeaponsEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            var unitComponent = filter.Get1(i);
            var equippingComponent = filter.Get2(i);

            ref var hasWeapon = ref entity.Get<EcsComponent.HasWeapon>();
            var setting = staticData.weaponSettings;
            var weaponGO = Object.Instantiate(setting.weaponPrefab, unitComponent.UnitGO.weaponHolder);
            var weaponEntity = ecsWorld.NewEntity();
            ref var weapon = ref weaponEntity.Get<EcsComponent.Weapon>();
            weapon.owner = entity;
            weapon.totalAmmo = setting.totalAmmo;
            weapon.weaponDamage = setting.weaponDamage;
            weapon.currentInMagazine = setting.currentInMagazine;
            weapon.maxInMagazine = setting.maxInMagazine;
            weapon.shootPosition = weaponGO.PointShoot;
            hasWeapon.weapon = weaponEntity;
            weaponGO.entity = weaponEntity;

            if (unitComponent.owner.Has<EcsComponent.Player>())
            {
                weaponGO.gameObject.AddComponent<LookAtMousePosition>();
                hud.HudWeapon.ShowAmmo(weapon.currentInMagazine);
                hud.HudWeapon.ShowMagazin(weapon.totalAmmo);
            }
            else
            {
                weaponGO.gameObject.AddComponent<LookAtTargetPosition>();
                weaponGO.RenderTransform.gameObject.layer = 7;
            }
        }
    }
}