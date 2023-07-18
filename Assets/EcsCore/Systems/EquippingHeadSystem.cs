using Leopotam.Ecs;
using UnityEngine;

internal class EquippingHeadSystem : IEcsRunSystem
{
    private Hud hud;
    private StaticData config;
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingHeadIntent, EcsComponent.Armor> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            entity.Get<EcsComponent.EquipHead>();
            ref var armor = ref filter.Get3(i).value;
            armor += config.itemData.Head.ArmorValue;
            if (entity.Has<EcsComponent.Player>())
            {
                hud.HudArmor.ShowArmor(armor, 100);
            }
            entity.Del<EcsComponent.EquippingHeadIntent>();
        }
    }
}