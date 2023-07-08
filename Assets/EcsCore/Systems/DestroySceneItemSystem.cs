using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class DestroySceneItemSystem : IEcsRunSystem
{
    private StaticData config;
    private Hud hud;
    private SceneData sceneData;
    private EcsFilter<EcsComponent.SceneItem, EcsComponent.DestroyEntityEvent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var itemGo = ref filter.Get1(i).itemGo;
            Debug.Log("Destroy Object:" + itemGo);
            itemGo.DestroySelf();
            filter.GetEntity(i).Destroy();
            
        }
    }
}