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
            }

            entity.Get<EcsComponent.EquippingWithWeaponsEvent>();

        }
    }

}