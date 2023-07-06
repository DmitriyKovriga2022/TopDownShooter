using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorldSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private StaticData config;
    private SceneData sceneData;

    public void Init()
    {
        sceneData.generateWorld.Initialise(config.gridData);
        sceneData.generateWorld.EventEndGeneration += GenerateWorld_EventEndGeneration;
        sceneData.generateWorld.StartGenerate();
    }

    private void GenerateWorld_EventEndGeneration()
    {
        sceneData.generateWorld.EventEndGeneration -= GenerateWorld_EventEndGeneration;
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        var iteration = 100;
        var unitCount = 1;
        while (unitCount > 0)
        {
            iteration--;
            if (RandomPoint(out Vector3 position))
            {
                var entity = ecsWorld.NewEntity();
                entity.Get<EcsComponent.SpawnUnitEvent>().position = position;
                //var unit = Object.Instantiate(config.unitPrefab, (Vector3)position, Quaternion.identity);
                //AiCombat aiCombat = unit.gameObject.AddComponent<AiCombat>();
                //aiCombat.Initialise(config.gridData);
                unitCount--;
            }

            if (iteration < 0)
            {
                Debug.LogError("Cant find free position for spawn unit");
                break;
            }
        }
    }

    private bool RandomPoint(out Vector3 position)
    {
        position = new Vector2(Random.Range(-config.gridData.GridSize.x / 2, config.gridData.GridSize.x / 2), 
                               Random.Range(-config.gridData.GridSize.y / 2, config.gridData.GridSize.y / 2));
        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(position, out hit, 10.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            position = hit.position;
            return true;
        }
        return false;
    }

}