using Leopotam.Ecs;
using UnityEngine;

internal class PlayerInputShootSystem : IEcsRunSystem
{
    private SceneData sceneData;
    private EcsFilter<EcsComponent.Player, EcsComponent.HasWeapon> filter;

    public void Run()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var i in filter)
            {
                var entity = filter.Get2(i).weapon;
                ref var ShootEvent = ref entity.Get<EcsComponent.ShootEvent>();
                ShootEvent.TargetPosition = sceneData.mainCamera.ScreenToWorldPoint(Input.mousePosition); 
            }
        }
    }

}