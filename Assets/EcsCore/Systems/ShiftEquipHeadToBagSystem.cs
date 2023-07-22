using Leopotam.Ecs;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ShiftEquipHeadToBagSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.ShiftHeadToBagEvent, EcsComponent.EquipHead, EcsComponent.Bag> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var item = ref filter.Get2(i);
            ItemConteiner conteiner = new HeadConteiner(item.configIndex);
            ref var bag = ref filter.Get3(i);
            bag.conteiners = bag.conteiners.Append(conteiner).ToArray();
        }
    }
}