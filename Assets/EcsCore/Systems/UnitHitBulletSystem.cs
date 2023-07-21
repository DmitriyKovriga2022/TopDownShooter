using Leopotam.Ecs;
using UnityEngine;

public class UnitHitBulletSystem : IEcsRunSystem
{
    private StaticData config;
    private Hud hud;
    private EcsFilter<EcsComponent.Health, EcsComponent.HitBulletEvent, EcsComponent.Unit, EcsComponent.EquipBody> filter;

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
            ref var body = ref filter.Get4(i);

            var armor = CalculateArmorValue(ItemData.Instance.Body[body.configIndex].ArmorValue, body.wearout);

            body.wearout += (int)power;
            body.wearout = Mathf.Clamp(body.wearout, 0, 100);

            armor = CalculateHitArmor((int)armor, (int)power, out int resultPower);

            if (armor <= 0)
            {
                health -= Mathf.RoundToInt(resultPower);
                health = Mathf.Clamp(health, 0, maxHealth);
            }
            else
            {
                health -= Mathf.RoundToInt(power / 100.0f * 10);
                health = Mathf.Clamp(health, 0, maxHealth);
            }

            //Debug.LogFormat("Health {0}: Armor {1}: Power {2}: ResultPower {3} ", health, armor, power, resultPower);

            int rnd = Random.Range(0, config.unitData.sound.hit.Length);
            SoundController.PlayClipAtPosition(config.unitData.sound.hit[rnd], unitGo.transform.position);

            if (unitEntity.Has<EcsComponent.Player>())
            {
                hud.HudHealth.ShowHealth(health, maxHealth);
                hud.HudArmor.ShowArmor((int)armor, 100);
            }

            if (health <= 0)
            {
                filter.GetEntity(i).Get<EcsComponent.UnitDeadEvent>();
            }
        }
    }

    private float CalculateArmorValue(int armor, int wearout)
    {
        float result = armor;
        if (wearout > 0)
        {
            float k = (armor / 100.0f) * wearout;
            result = armor - k;
            //Debug.LogFormat("Armor {0} wearout {1} k {2} result {3} ", armor, wearout, k, result);
        }
        return result;
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