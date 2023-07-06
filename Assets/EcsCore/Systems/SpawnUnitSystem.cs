using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class SpawnUnitSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private SceneData sceneData;
    private Hud hud;
    private EcsFilter<EcsComponent.SpawnUnitEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            ref var unit = ref entity.Get<EcsComponent.Unit>();
            ref var spawnUnitEvent = ref filter.Get1(i);
            var unitGO = Object.Instantiate(staticData.unitPrefab, spawnUnitEvent.position, Quaternion.identity);
            unitGO.entity = entity;
            unit.owner = entity;
            unit.UnitGO = unitGO;

            if (unit.owner.Has<EcsComponent.Player>())
            {
            }
            else
            {
                AiCombat aiCombat = unitGO.gameObject.AddComponent<AiCombat>();
                aiCombat.Initialise(staticData.gridData.GridSize, sceneData.player);

                unitGO.visualTransform.gameObject.layer = 7;
            }

            entity.Get<EcsComponent.EquippingWithWeaponsEvent>();
        }
    }

}