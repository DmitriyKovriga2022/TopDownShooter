using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorldSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private SceneData sceneData;

    public void Init()
    {
        sceneData.generateBackground.StartGenerate();
    }
}