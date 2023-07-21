using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBagSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.SaveBagEvent, EcsComponent.Bag> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            var bag = filter.Get2(i);
            SaveLoadManager.Save(bag, "Bag" + entity.GetInternalId());
            //var otherEntity = filter.Get1(i).entity;
            
        }
    }
}
