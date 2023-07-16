using Leopotam.Ecs;
using System.Collections;
using System.Linq;
using UnityEngine;

public class RemoveEmptyConteinersSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private Hud hud;
    private EcsFilter<EcsComponent.Bag> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var conteiners = ref filter.Get1(i).conteiners;
            conteiners = conteiners.Where(x => x.GetContent() != 0).ToArray();
        } 
    }
}