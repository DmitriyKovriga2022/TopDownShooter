using Leopotam.Ecs;
using UnityEngine;

internal class EquippingWeaponSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private Hud hud;
    private EcsFilter<EcsComponent.Unit, EcsComponent.Bag, EcsComponent.EquippingWeaponEvent> filter;

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
            weapon.weaponDamage = setting.weaponDamage;
            weapon.currentInMagazine = setting.currentInMagazine;
            weapon.maxInMagazine = setting.maxInMagazine;
            weapon.shootPosition = weaponGO.PointShoot;

            ref var conteiners = ref filter.Get2(i).conteiners;

            if (unitComponent.owner.Has<EcsComponent.Player>())
            {
                hud.HudWeapon.ShowMagazine(weapon.currentInMagazine);
                hud.HudWeapon.ShowTotalAmmo(GetTotalAmmo(conteiners));
            }
            else
            {
                weaponGO.RenderTransform.gameObject.layer = 7;
            }
        }
    }

    private int GetTotalAmmo(ItemConteiner[] conteiners)
    {
        for (int i = 0; i < conteiners.Length; i++)
        {
            if (conteiners[i] is AmmoConteiner)
            {
                return (conteiners[i] as AmmoConteiner).GetContent();
            }
        }

        return 0;
    }
}