using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class RemoveBodySystem : IEcsRunSystem
{
    private Hud hud;
    private StaticData config;
    private EcsFilter<EcsComponent.EquipBody, EcsComponent.RemoveEqipBodyEvent, EcsComponent.Armor> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            Debug.Log("RemoveBodySystem");
            var entity = filter.GetEntity(i);
            ref var armorValue = ref filter.Get3(i).value;
            armorValue -= config.itemData.Jacket.ArmorValue;
            armorValue = Mathf.Clamp(armorValue, 0, int.MaxValue);
            if (entity.Has<EcsComponent.Player>())
            {
                hud.HudArmor.ShowArmor(armorValue, 100);
            }
            filter.GetEntity(i).Del<EcsComponent.EquipBody>();
        }
    }
}