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

            if (Cursor.visible)
            {
                input.direction = Vector2.zero;
            }
            else
            {
                input.direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }
    }
}