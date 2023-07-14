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
            health.value = 100;
            health.maxValue = 100;

            ref var purse = ref entity.Get<EcsComponent.Purse>();
            ref var position = ref filter.Get1(i).position;
            ref var unitType = ref filter.Get1(i).unitType;

            var unitGO = Object.Instantiate(staticData.unitData.unitPrefab, position, Quaternion.identity);
            unitGO.entity = entity;
            unit.owner = entity;
            unit.UnitGO = unitGO;
            

            if (unit.owner.Has<EcsComponent.Player>() == true) continue;

            //AiCombat aiCombat = unitGO.gameObject.AddComponent<AiCombat>();
            //aiCombat.Initialise(staticData.gridData.GridSize, sceneData.player);
            //unitGO.visualTransform.gameObject.layer = 7;
            //purse.value = Random.Range(0, 10);

            var merchant = unitGO.gameObject.AddComponent<AiMerchant>();
            merchant.Initialise(StaticData.Instance.gridData.GridSize,
                                StaticData.Instance.merchantConversation);

            ref var bag = ref entity.Get<EcsComponent.Bag>();
            bag.conteiners = new ItemConteiner[5]
             {
                new AmmoConteiner(Random.Range(1, 50)),
                new MedKitConteiner(Random.Range(10, 50)),
                new WeaponConteiner(1),
                new ArmorConteiner(1),
                new FoodConteiner(Random.Range(1, 50)),
             };


            entity.Get<EcsComponent.EquipWeapon>();
            entity.Get<EcsComponent.EquipWeaponSecond>();
            entity.Get<EcsComponent.EquipBody>();
            entity.Get<EcsComponent.EquipHead>();
            //entity.Get<EcsComponent.EquippingWeaponEvent>();

        }
    }

    private void InstantiateGo()
    {

    }

}