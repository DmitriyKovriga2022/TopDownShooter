using Leopotam.Ecs;
using UnityEngine;

public class SpawnUnitSystem : IEcsRunSystem
{
    private StaticData staticData;
    private SceneData sceneData;
    private EcsFilter<EcsComponent.SpawnUnitEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            ref var unit = ref entity.Get<EcsComponent.Unit>();
            ref var health = ref entity.Get<EcsComponent.Health>();
            ref var purse = ref entity.Get<EcsComponent.Purse>();
            ref var spawnUnitEvent = ref filter.Get1(i);

            var unitGO = Object.Instantiate(staticData.unitData.unitPrefab, spawnUnitEvent.position, Quaternion.identity);
            unitGO.entity = entity;
            unit.owner = entity;
            unit.UnitGO = unitGO;
            health.value = 100;
            health.maxValue = 100;

            if (unit.owner.Has<EcsComponent.Player>() == false)
            {
                AiCombat aiCombat = unitGO.gameObject.AddComponent<AiCombat>();
                aiCombat.Initialise(staticData.gridData.GridSize, sceneData.player);
                unitGO.visualTransform.gameObject.layer = 7;

                purse.value = Random.Range(0, 10);

            }

            ref var bag = ref entity.Get<EcsComponent.Bag>();
            bag.conteiners = new ItemConteiner[5]
             {
                new AmmoConteiner(Random.Range(1, 50)),
                new MedKitConteiner(Random.Range(10, 50)),
                new WeaponConteiner(1),
                new ArmorConteiner(1),
                new FoodConteiner(Random.Range(1, 50)),
             };
            //entity.Get<EcsComponent.EquippingWeaponEvent>();

        }
    }

}