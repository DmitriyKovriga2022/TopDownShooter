using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class RemoveHeadSystem : IEcsRunSystem
{
    private Hud hud;
    private StaticData config;
    private EcsFilter<EcsComponent.EquipHead, EcsComponent.RemoveEqipHeadEvent, EcsComponent.Armor> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            Debug.Log("RemoveHeadSystem");
            var entity = filter.GetEntity(i);
            ref var armorValue = ref filter.Get3(i).value;
            armorValue -= config.itemData.Head.ArmorValue;
            armorValue = Mathf.Clamp(armorValue, 0, int.MaxValue);
            if (entity.Has<EcsComponent.Player>())
            {
                hud.HudArmor.ShowArmor(armorValue, 100);
            }
            filter.GetEntity(i).Del<EcsComponent.EquipHead>();
        }
    }
}