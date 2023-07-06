using Leopotam.Ecs;
using UnityEngine;

public class UnitHitBulletSystem : IEcsRunSystem
{
    private StaticData config;
    private Hud hud;
    private EcsFilter<EcsComponent.Health, EcsComponent.HitBulletEvent, EcsComponent.Unit> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var health = ref filter.Get1(i).value;
            ref var maxHealth = ref filter.Get1(i).maxValue;
            ref var power = ref filter.Get2(i).hitPower;
            ref var unitGo = ref filter.Get3(i).UnitGO;
            ref var unitEntity = ref filter.Get3(i).owner;

            health -= Mathf.RoundToInt(power);
            health = Mathf.Clamp(health, 0, maxHealth);

            int rnd = Random.Range(0, config.unitData.sound.hit.Length);
            SoundController.PlayClipAtPosition(config.unitData.sound.hit[rnd], unitGo.transform.position);

            if (unitEntity.Has<EcsComponent.Player>())
            {
                hud.HudHealth.ShowHealth(health, maxHealth);
            }

            if(health <= 0)
            {
                filter.GetEntity(i).Get<EcsComponent.UnitDeadEvent>();
            }

        }
    }
}