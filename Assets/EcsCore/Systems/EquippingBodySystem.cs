using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class EquippingBodySystem : IEcsRunSystem
{
    private Hud hud;
    private StaticData config;
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingBodyIntent, EcsComponent.Armor> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            entity.Get<EcsComponent.EquipBody>();
            ref var armor = ref filter.Get3(i).value;
            armor += config.itemData.Jacket.ArmorValue;

            if (entity.Has<EcsComponent.Player>())
            {
                hud.HudArmor.ShowArmor(armor, 100);
            }

            entity.Del<EcsComponent.EquippingBodyIntent>();
        }
    }
}