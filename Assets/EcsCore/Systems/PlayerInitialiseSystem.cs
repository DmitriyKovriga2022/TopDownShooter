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

        var unitGo = Object.Instantiate(staticData.unitData.unitPrefab);
        var playerGo = unitGo.gameObject.AddComponent<UnityComponent.Player>();
        unitGo.name = "Player";
        unitGo.entity = playerEntity;
        entity.mainTransform = unitGo.mainTransform;
        entity.visualTransform = unitGo.visualTransform;

        unit.owner = playerEntity;
        unit.UnitGO = unitGo;
        playerGo.entity = playerEntity;

        health.value = 100;
        health.maxValue = 100;

        motion.rigidbody = unitGo.rigidbody;
        motion.speed = staticData.unitData.unitSpeed;

        sceneData.fovFollowTarget.Target = entity.mainTransform;
        sceneData.player = unitGo;

        hud.HudHealth.ShowHealth(health.value, health.maxValue);

        playerEntity.Get<EcsComponent.EquippingWeaponEvent>();

    }

}
