using Leopotam.Ecs;
using UnityEngine;

internal class PlayerInputSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Player, EcsComponent.DesiredMoveDirection> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var input = ref filter.Get2(i);
            input.direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}