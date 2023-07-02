using Leopotam.Ecs;
using UnityEngine;

internal class CameraFollowSystem : IEcsRunSystem
{
    private SceneData sceneData;
    private StaticData staticData;

    private EcsFilter<EcsComponent.Player> filter;

    private Vector3 currentVelocity;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var player = ref filter.Get1(i);

            var cameraPos = sceneData.mainCamera.transform.position;
            var playerPos = player.transform.position;
            playerPos.z = cameraPos.z;

            cameraPos = Vector3.SmoothDamp(cameraPos, playerPos, ref currentVelocity, staticData.smoothTime);
            sceneData.mainCamera.transform.position = cameraPos;
        }
    }
}