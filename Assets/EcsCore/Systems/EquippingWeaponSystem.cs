using Leopotam.Ecs;
using UnityEngine;

internal class EquippingWeaponSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private Hud hud;
    private EcsFilter<EcsComponent.Unit, EcsComponent.Bag, EcsComponent.EquippingWeaponIntent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            Debug.Log("Equip Weapon");

            var entity = filter.GetEntity(i);
            var unitComponent = filter.Get1(i);
            var configIndex = filter.Get2(i).configIndex;
            ref var weapon = ref entity.Get<EcsComponent.EquipWeaponMain>();
            weapon.configIndex = configIndex;
            var setting = ItemData.Instance.Weapon[configIndex].Settings;
            var weaponGO = Object.Instantiate(setting.weaponPrefab, unitComponent.UnitGO.weaponHolder);
            weaponGO.gameObject.AddComponent<UnityComponent.LookAtPosition>();
            weapon.WeaponGo = weaponGO;
            weapon.weaponDamage = setting.weaponDamage;
            weapon.currentInMagazine = setting.maxInMagazine;
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

            entity.Del<EcsComponent.EquippingWeaponIntent>();
        }
    }

    private int GetTotalAmmo(ItemConteiner[] conteiners)
    {
        for (int i = 0; i < conteiners.Length; i++)
        {
            if (conteiners[i] is AmmoConteiner)
            {
                return (conteiners[i] as AmmoConteiner).GetCount();
            }
        }

        return 0;
    }
}