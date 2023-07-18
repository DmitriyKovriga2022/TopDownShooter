using Leopotam.Ecs;
using UnityEngine;

public class UnitHitBulletSystem : IEcsRunSystem
{
    private StaticData config;
    private Hud hud;
    private EcsFilter<EcsComponent.Health, EcsComponent.HitBulletEvent, EcsComponent.Unit, EcsComponent.Armor> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            ref var health = ref filter.Get1(i).value;
            ref var maxHealth = ref filter.Get1(i).maxValue;
            ref var power = ref filter.Get2(i).hitPower;
            ref var unitGo = ref filter.Get3(i).UnitGO;
            ref var unitEntity = ref filter.Get3(i).owner;
            ref var armor = ref filter.Get4(i).value;

            armor = CalculateHitArmor(armor, (int)power, out int resultPower);

            if (armor <= 0)
            {
                health -= Mathf.RoundToInt(resultPower);
                health = Mathf.Clamp(health, 0, maxHealth);
            }

            int rnd = Random.Range(0, config.unitData.sound.hit.Length);
            SoundController.PlayClipAtPosition(config.unitData.sound.hit[rnd], unitGo.transform.position);

            if (unitEntity.Has<EcsComponent.Player>())
            {
                hud.HudHealth.ShowHealth(health, maxHealth);
                hud.HudArmor.ShowArmor(armor, 100);
            }

            if (health <= 0)
            {
                filter.GetEntity(i).Get<EcsComponent.UnitDeadEvent>();
            }
        }
    }

    public int CalculateHitArmor(int armor, int power, out int resultPower)
    {
        resultPower = power - armor;
        resultPower = Mathf.Clamp(resultPower, 0, int.MaxValue);

        int resultArmor = armor - power;
        resultArmor = Mathf.Clamp(resultArmor, 0, int.MaxValue);

        return resultArmor;
    }

}