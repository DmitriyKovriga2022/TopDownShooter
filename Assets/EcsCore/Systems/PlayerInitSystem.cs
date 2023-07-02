using Leopotam.Ecs;
using UnityEngine;

internal class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private SceneData sceneData;
    private Hud hud;

    public void Init()
    {
        var playerEntity = ecsWorld.NewEntity();

        ref var player = ref playerEntity.Get<EcsComponent.Player>();
        ref var motion = ref playerEntity.Get<EcsComponent.UnitMotion>();
        ref var inputData = ref playerEntity.Get<EcsComponent.DesiredMoveDirection>();
        ref var hasWeapon = ref playerEntity.Get<EcsComponent.HasWeapon>();

        var playerGO = Object.Instantiate(staticData.playerPrefab);
        playerGO.entity = playerEntity;
        player.transform = playerGO.transform;
        motion.rigidbody = playerGO.rigidbody;
        motion.speed = staticData.playerSpeed;

        var weaponGO = playerGO.GetComponentInChildren<WeaponSettings>();
        var weaponEntity = ecsWorld.NewEntity();
        ref var weapon = ref weaponEntity.Get<EcsComponent.Weapon>();
        weapon.owner = playerEntity;
        weapon.totalAmmo = weaponGO.totalAmmo;
        weapon.weaponDamage = weaponGO.weaponDamage;
        weapon.currentInMagazine = weaponGO.currentInMagazine;
        weapon.maxInMagazine = weaponGO.maxInMagazine;
        weapon.shootPosition = weaponGO.shootPosition;

        hasWeapon.weapon = weaponEntity;

        hud.hudWeapon.ShowAmmo(weapon.currentInMagazine);
        hud.hudWeapon.ShowMagazin(weapon.totalAmmo);

        sceneData.fovFollowTarget.Target = player.transform;
    }
}
