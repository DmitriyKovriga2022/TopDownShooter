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
            ref var position = ref filter.Get1(i).position;
            ref var unitType = ref filter.Get1(i).unitType;
            ref var unit = ref entity.Get<EcsComponent.Unit>();
            ref var health = ref entity.Get<EcsComponent.Health>();
            ref var armor = ref entity.Get<EcsComponent.Armor>();
            health.value = 100;
            health.maxValue = 100;

            var unitGO = Object.Instantiate(staticData.unitData.unitPrefab, position, Quaternion.identity);
            unitGO.Initialise(entity);
            unit.owner = entity;
            unit.UnitGO = unitGO;

            if (unit.owner.Has<EcsComponent.Player>() == true) continue;

            var ai = Object.Instantiate(staticData.aiPrefab, unit.UnitGO.transform);
            ai.Initialise(entity);

            ref var bag = ref entity.Get<EcsComponent.Bag>();
            bag.conteiners = new ItemConteiner[5]
             {
                new AmmoConteiner(Random.Range(25, 50)),
                new MedKitConteiner(Random.Range(10, 50)),
                new WeaponConteiner(1),
                new BodyConteiner(1),
                new FoodConteiner(Random.Range(1, 50)),
             };

            ref var purse = ref entity.Get<EcsComponent.Purse>();

            //entity.Get<EcsComponent.EquipWeapon>();
            //entity.Get<EcsComponent.EquipWeaponSecond>();
            //entity.Get<EcsComponent.EquipBody>();
            //entity.Get<EcsComponent.EquipHead>();


            //ref var character = ref filter.Get1(i).unitType;
            //if (character == UnitType.Combat)
            //{
            //    AiCombat aiCombat = unitGO.gameObject.AddComponent<AiCombat>();
            //    aiCombat.Initialise(entity,staticData.gridData.GridSize);
            //    unitGO.visualTransform.gameObject.layer = 7;
            //    purse.value = Random.Range(0, 10);
            //   // entity.Get<EcsComponent.EquippingWeaponEvent>();
            //}
            //if (character == UnitType.Netral)
            //{
            //    AiCombat aiCombat = unitGO.gameObject.AddComponent<AiCombat>();
            //    aiCombat.Initialise(entity, staticData.gridData.GridSize);
            //    unitGO.visualTransform.gameObject.layer = 7;
            //    purse.value = Random.Range(0, 10);
            //   // entity.Get<EcsComponent.EquippingWeaponEvent>();
            //}

        }
    }

}