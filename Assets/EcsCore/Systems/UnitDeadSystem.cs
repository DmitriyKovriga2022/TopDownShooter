using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class UnitDeadSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData config;
    private Hud hud;
    private SceneData sceneData;
    private EcsFilter<EcsComponent.Unit, EcsComponent.UnitDeadEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var unitGo = ref filter.Get1(i).UnitGO;

            int rnd = Random.Range(0, config.unitData.sound.dead.Length);
            SoundController.PlayClipAtPosition(config.unitData.sound.dead[rnd], unitGo.transform.position);

            if (filter.GetEntity(i).Has<EcsComponent.Bag>())
            {
                var entity = ecsWorld.NewEntity();
                ref var bag = ref filter.GetEntity(i).Get<EcsComponent.Bag>();
                entity.Replace(bag);
                entity.Get<EcsComponent.DropToGroundEvent>().position = unitGo.transform.position;
            }

            if (filter.GetEntity(i).Has<EcsComponent.HasWeapon>())
            {
                ref var hasWeapon = ref filter.GetEntity(i).Get<EcsComponent.HasWeapon>();
                hasWeapon.weapon.Get<EcsComponent.DropToGroundEvent>();
            }

            if (filter.GetEntity(i).Has<EcsComponent.Player>())
            {
                hud.ShowDeadPanel();
                sceneData.fovFollowTarget.Target = null;
                sceneData.player = null;
            }

            unitGo.Dead();
            filter.GetEntity(i).Destroy();
        }
    }
}