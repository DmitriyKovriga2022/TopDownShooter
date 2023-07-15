using Leopotam.Ecs;
using UnityEngine;


sealed class EcsStartup : MonoBehaviour
{
    public StaticData configuration;
    public SceneData sceneData;
    public Hud hud;

    EcsWorld _world;
    EcsSystems _initSystems;
    EcsSystems _updateSystems;
    EcsSystems _fixedUpdateSystems;
    EcsSystems _lateUpdateSystems;

    void Start()
    {
        // void can be switched to IEnumerator for support coroutines.

        _world = new EcsWorld();
        EcsWorldsProvider.SetWorld(_world);

        _initSystems = new EcsSystems(_world);
        _updateSystems = new EcsSystems(_world);
        _fixedUpdateSystems = new EcsSystems(_world);
        _lateUpdateSystems = new EcsSystems(_world);

#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedUpdateSystems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_lateUpdateSystems);
#endif

        _initSystems
                .Add(new FindSceneItemMarker())
                .Add(new FindUnitSceneMarkerSystem())
                .Add(new PlayerInitialiseSystem())

                .Inject(configuration)
                .Inject(sceneData)
                .Inject(hud);

        _updateSystems
              // register your systems here, for example:
              //.Add(new GenerateWorldSystem())
             .Add(new SpawnUnitSystem())
             .Add(new SpawnSceneItemSystem())
             .Add(new SpawnProjectileSystem())

             .Add(new EquippingWeaponSystem())
             .Add(new EquippingAmmoSystem())
             
             .Add(new PlayerInputShootSystem())
             .Add(new PickUpItemSystem())
             .Add(new ApplyMedKitSystem())

             .Add(new WeaponReloadingSystem())
             .Add(new WeaponShootSystem())

             .Add(new PlayerRotationSystem())
             .Add(new ProjectileMoveSystem())
             .Add(new ProjectileHitSystem())
             .Add(new UnitHitBulletSystem())
             .Add(new LiveTimeSystem())

             .Add(new UnitDeadSystem())
             .Add(new DropToGroundWeaponSystem())
             .Add(new DropToGroundBagSystem())
             
             .Add(new ShowTradeMenuSystem())
             .Add(new ShowEquipMenuSystem())
             .Add(new ShowBagUISystem())

             .Add(new DestroySceneItemSystem())
             .Add(new RemoveMainWeaponSystem())

             // register one-frame components (order is important), for example:
             .OneFrame<EcsComponent.ShootEvent>()
             .OneFrame<EcsComponent.SpawnProjectileEvent>()
             .OneFrame<EcsComponent.TryReloadEvent>()
             .OneFrame<EcsComponent.ProjectileHitEvent>()
             .OneFrame<EcsComponent.PickUpSceneItemEvent>()
             .OneFrame<EcsComponent.EquippingWeaponEvent>()
             .OneFrame<EcsComponent.EquippingAmmoEvent>()
             .OneFrame<EcsComponent.ShowTradeMenuEvent>()
             .OneFrame<EcsComponent.ShowUIBagEvent>()
             .OneFrame<EcsComponent.ShowUIEquipEvent>()
             .OneFrame<EcsComponent.RemoveEqipMainWeaponEvent>()
             .OneFrame<EcsComponent.SpawnUnitEvent>()
             .OneFrame<EcsComponent.SpawnSceneItemEvent>()
             .OneFrame<EcsComponent.HitBulletEvent>()
             .OneFrame<EcsComponent.UnitDeadEvent>()
             .OneFrame<EcsComponent.DropToGroundEvent>()
             .OneFrame<EcsComponent.DestroyEntityEvent>()
             .OneFrame<EcsComponent.ApplyMedKitEvent>()

             // inject service instances here (order doesn't important), for example:
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(hud);

        _fixedUpdateSystems
            .Add(new PlayerInputSystem())
            .Add(new PlayerMoveSystem())
            .Add(new CameraFollowSystem())
            .Inject(configuration)
            .Inject(sceneData);


        _initSystems.Init();
        _updateSystems.Init();
        _fixedUpdateSystems.Init();
        _lateUpdateSystems.Init();

    }

    void Update()
    {
        _updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        _fixedUpdateSystems?.Run();
    }

    private void LateUpdate()
    {
        _lateUpdateSystems?.Run();
    }

    void OnDestroy()
    {
        if (_initSystems != null)
        {
            _initSystems.Destroy();
            _initSystems = null;
        }


        if (_updateSystems != null)
        {
            _updateSystems.Destroy();
            _updateSystems = null;
        }

        if (_fixedUpdateSystems != null)
        {
            _fixedUpdateSystems.Destroy();
            _fixedUpdateSystems = null;
        }

        if (_lateUpdateSystems != null)
        {
            _lateUpdateSystems.Destroy();
            _lateUpdateSystems = null;
        }

        if (_world != null)
        {
            _world.Destroy();
            _world = null;
        }
    }
}
