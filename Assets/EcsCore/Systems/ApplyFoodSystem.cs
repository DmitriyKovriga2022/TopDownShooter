using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class ApplyFoodSystem : IEcsRunSystem
{
    private Hud hud;
    private EcsFilter<EcsComponent.Health, EcsComponent.ApplyFoodEvent, EcsComponent.Unit> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var medKitValue = ref filter.Get2(i).Power;
            ref var health = ref filter.Get1(i).value;
            ref var maxHealth = ref filter.Get1(i).maxValue;
            ref var unitEntity = ref filter.Get3(i).owner;

            health += medKitValue;
            health = Mathf.Clamp(health, 0, maxHealth);

            if (unitEntity.Has<EcsComponent.Player>())
            {
                hud.HudHealth.ShowHealth(health, maxHealth);
            }
        }
    }
}