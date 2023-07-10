using Leopotam.Ecs;
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
        SpawnAmmoBox();
        SpawnMedKit();
    }

    private void SpawnEnemy()
    {
        var iteration = 100;
        var unitCount = 20;
        while (unitCount > 0)
        {
            iteration--;
            if (RandomPoint(out Vector3 position))
            {
                var entity = ecsWorld.NewEntity();
                entity.Get<EcsComponent.SpawnUnitEvent>().position = position;
                unitCount--;
            }

            if (iteration < 0)
            {
                Debug.LogError("Cant find free position for spawn unit");
                break;
            }
        }
    }

    private void SpawnAmmoBox()
    {
        var iteration = 100;
        var itemCount = 10;
        while (itemCount > 0)
        {
            iteration--;
            if (RandomPoint(out Vector3 position))
            {
                var entity = ecsWorld.NewEntity();
                ref var component = ref entity.Get<EcsComponent.SpawnSceneItemEvent>();
                component.position = position;
                component.conteiners = new ItemConteiner[1]{new AmmoConteiner(30)};
                itemCount--;
            }

            if (iteration < 0)
            {
                Debug.LogError("Cant find free position for spawn unit");
                break;
            }
        }
    }

    private void SpawnMedKit()
    {
        var iteration = 100;
        var itemCount = 10;
        while (itemCount > 0)
        {
            iteration--;
            if (RandomPoint(out Vector3 position))
            {
                var entity = ecsWorld.NewEntity();
                ref var component = ref entity.Get<EcsComponent.SpawnSceneItemEvent>();
                component.position = position;
                component.conteiners = new ItemConteiner[1] {new MedKitConteiner(50)};
                itemCount--;
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