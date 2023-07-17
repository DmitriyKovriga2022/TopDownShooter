using Leopotam.Ecs;
using UnityEngine;

internal class PlayerInputShootSystem : IEcsRunSystem
{
    private SceneData sceneData;
    private EcsFilter<EcsComponent.Player, EcsComponent.EquipWeapon> filter;

    public void Run()
    {
        if (Cursor.visible) return;

        if (Input.GetMouseButtonDown(0))
        {
            foreach (var i in filter)
            {
                var entity = filter.GetEntity(i);
                ref var ShootEvent = ref entity.Get<EcsComponent.ShootEvent>();
                ShootEvent.TargetPosition = sceneData.mainCamera.ScreenToWorldPoint(Input.mousePosition); 
           
            }
        }
    }

}