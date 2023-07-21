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

    private void InitialisePlayerUnit(EcsEntity entity)
    {
        ref var player = ref entity.Get<EcsComponent.Player>();
        ref var unit = ref entity.Get<EcsComponent.Unit>();
        ref var motion = ref entity.Get<EcsComponent.UnitMotion>();
        ref var inputData = ref entity.Get<EcsComponent.DesiredMoveDirection>();
        ref var health = ref entity.Get<EcsComponent.Health>();
        ref var armor = ref entity.Get<EcsComponent.Armor>();
        var unitGo = Object.Instantiate(staticData.unitData.unitPrefab);
        unitGo.Initialise(entity);

        var playerGo = unitGo.gameObject.AddComponent<UnityComponent.Player>();
        unitGo.name = "Player";
        unitGo.selfEntity = entity;
        player.mainTransform = unitGo.mainTransform;
        player.visualTransform = unitGo.visualTransform;

        unit.owner = entity;
        unit.UnitGO = unitGo;
        playerGo.entity = entity;

        health.value = 100;
        health.maxValue = 100;

        motion.rigidbody = unitGo.rigidbody;
        motion.speed = staticData.unitData.unitSpeed;

        sceneData.fovFollowTarget.Target = player.mainTransform;
        sceneData.fovFollowTarget.transform.parent = player.mainTransform;
        sceneData.player = unitGo;

        hud.HudHealth.ShowHealth(health.value, health.maxValue);
        hud.HudArmor.ShowArmor(armor.value, 100);

        ref var bag = ref entity.Get<EcsComponent.Bag>();
        bag.conteiners = new ItemConteiner[6]
         {
                new AmmoConteiner(30, 0),
                new MedKitConteiner(0),
                new FoodConteiner(5, 0),
                new BodyConteiner(0, 0),
                new WeaponConteiner(0, 0),
                new HeadConteiner(0),
         };

        //entity.Get<EcsComponent.EquippingWeaponEvent>();

    }

}
