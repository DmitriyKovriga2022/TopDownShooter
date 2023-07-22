using Leopotam.Ecs;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ShiftEquipBodyToBagSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.ShiftBodyToBagEvent, EcsComponent.EquipBody, EcsComponent.Bag> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var entity = ref filter.GetEntity(i);
            ref var item = ref filter.Get2(i);
            ItemConteiner conteiner = new BodyConteiner(item.configIndex, item.wearout);
            ref var bag = ref filter.Get3(i);
            bag.conteiners = bag.conteiners.Append(conteiner).ToArray();
            entity.Del<EcsComponent.EquipBody>();
        }
    }
}
