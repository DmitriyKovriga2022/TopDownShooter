using Leopotam.Ecs;
using UnityEngine;

internal class PlayerInitialiseSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private SceneData sceneData;

    public void Init()
    {
        InitialisePlayerUnit(ecsWorld.NewEntity());
    }

    private void InitialisePlayerUnit(EcsEntity playerEntity)
    {
        ref var player = ref playerEntity.Get<EcsComponent.Player>();
        ref var unit = ref playerEntity.Get<EcsComponent.Unit>();
        ref var motion = ref playerEntity.Get<EcsComponent.UnitMotion>();
        ref var inputData = ref playerEntity.Get<EcsComponent.DesiredMoveDirection>();

        var playerGO = Object.Instantiate(staticData.unitPrefab);
        playerGO.name = "Player";
        playerGO.entity = playerEntity;
        player.mainTransform = playerGO.mainTransform;
        player.visualTransform = playerGO.visualTransform;

        unit.owner = playerEntity;
        unit.UnitGO = playerGO;

        

        motion.rigidbody = playerGO.rigidbody;
        motion.speed = staticData.unitSpeed;

        sceneData.fovFollowTarget.Target = player.mainTransform;
        sceneData.player = playerGO;

        playerEntity.Get<EcsComponent.EquippingWithWeaponsEvent>();
    }

}
