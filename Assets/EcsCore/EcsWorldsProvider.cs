using Leopotam.Ecs;
using UnityEngine;

public static class EcsWorldsProvider
{
    public static EcsWorld World => _world;
    private static EcsWorld _world;

    public static void SetWorld(EcsWorld world)
    {
        _world = world;
    }

}