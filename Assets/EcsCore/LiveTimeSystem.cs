using Leopotam.Ecs;
using UnityEngine;

internal class LiveTimeSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.LiveTime> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            if (filter.Get1(i).EndTime <= Time.time)
            {
                filter.Get1(i).gameObject.DestroySelf();
                filter.GetEntity(i).Destroy();
            }
        }
    }
}