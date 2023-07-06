using Leopotam.Ecs;
using UnityEngine;

internal class PlayerInitialiseSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private SceneData sceneData;
    private Hud hud;

    public void Init()
    {
        InitialisePlayerUnit(ecsWorld.NewEntity());
    }

    private void InitialisePlayerUnit(EcsEntity playerEntity)
    {
        ref var entity = ref playerEntity.Get<EcsComponent.Player>();
        ref var unit = ref playerEntity.Get<EcsComponent.Unit>();
        ref var motion = ref playerEntity.Get<EcsComponent.UnitMotion>();
        ref var inputData = ref playerEntity.Get<EcsComponent.DesiredMoveDirection>();
        ref var health = ref playerEntity.Get<EcsComponent.Health>();

        var playerGO = Object.Instantiate(staticData.unitData.unitPrefab);
        playerGO.name = "Player";
        playerGO.entity = playerEntity;
        entity.mainTransform = playerGO.mainTransform;
        entity.visualTransform = playerGO.visualTransform;

        unit.owner = playerEntity;
        unit.UnitGO = playerGO;

        health.value = 100;
        health.maxValue = 100;

        motion.rigidbody = playerGO.rigidbody;
        motion.speed = staticData.unitData.unitSpeed;

        sceneData.fovFollowTarget.Target = entity.mainTransform;
        sceneData.player = playerGO;

        hud.HudHealth.ShowHealth(health.value, health.maxValue);

        playerEntity.Get<EcsComponent.EquippingWithWeaponsEvent>();

    }

}
