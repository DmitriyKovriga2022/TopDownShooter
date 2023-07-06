using Leopotam.Ecs;
using UnityEngine;


sealed class EcsStartup : MonoBehaviour
{
    public StaticData configuration;
    public SceneData sceneData;
    public Hud hud;

    public EcsWorld World => _world;
    EcsWorld _world;
    EcsSystems _updateSystems;
    EcsSystems _fixedUpdateSystems;
    EcsSystems _lateUpdateSystems;

    void Start()
    {
        // void can be switched to IEnumerator for support coroutines.

        _world = new EcsWorld();
        _updateSystems = new EcsSystems(_world);
        _fixedUpdateSystems = new EcsSystems(_world);
        _lateUpdateSystems = new EcsSystems(_world);

#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedUpdateSystems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_lateUpdateSystems);
#endif

        _updateSystems
             // register your systems here, for example:
             .Add(new GenerateWorldSystem())
             .Add(new PlayerInitialiseSystem())
             .Add(new SpawnUnitSystem())
             .Add(new PlayerRotationSystem())
             .Add(new PlayerInputShootSystem())
             .Add(new EquippingWithWeaponsSystem())
             .Add(new WeaponShootSystem())
             .Add(new WeaponReloadingSystem())
             .Add(new SpawnProjectileSystem())
             .Add(new ProjectileMoveSystem())
             .Add(new ProjectileHitSystem())
             .Add(new UnitHitBulletSystem())
             .Add(new LiveTimeSystem())
             .Add(new ItemCollisionSystem())
             .Add(new PickUpItemSystem())
             .Add(new UnitDeadSystem())
             

             // register one-frame components (order is important), for example:
             .OneFrame<EcsComponent.ShootEvent>()
             .OneFrame<EcsComponent.SpawnProjectileEvent>()
             .OneFrame<EcsComponent.TryReloadEvent>()
             .OneFrame<EcsComponent.ProjectileHitEvent>()
             .OneFrame<EcsComponent.UnitCollisionEvent>()
             .OneFrame<EcsComponent.ItemCollisionEvent>()
             .OneFrame<EcsComponent.PickUpItemEvent>()
             .OneFrame<EcsComponent.EquippingWithWeaponsEvent>()
             .OneFrame<EcsComponent.SpawnUnitEvent>()
             .OneFrame<EcsComponent.HitBulletEvent>()
             .OneFrame<EcsComponent.UnitDeadEvent>()

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
