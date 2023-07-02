using Leopotam.Ecs;
using UnityEngine;

internal class PlayerRotationSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Player> filter;
    private SceneData sceneData;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var player = ref filter.Get1(i);

            Vector2 cursorPosition = sceneData.mainCamera.ScreenToWorldPoint(Input.mousePosition);
            
            if (cursorPosition.x < player.mainTransform.position.x)
            {
                player.visualTransform.eulerAngles = Vector3.up * 180;
            }
            else
            {
                player.visualTransform.eulerAngles = Vector3.zero;
            }

        }
    }
}