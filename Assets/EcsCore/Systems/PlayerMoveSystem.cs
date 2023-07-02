using Leopotam.Ecs;
using UnityEngine;

internal class PlayerMoveSystem : IEcsRunSystem
{
    private Vector2 direction;
    private EcsFilter<EcsComponent.Player, EcsComponent.UnitMotion, EcsComponent.DesiredMoveDirection> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var motion = ref filter.Get2(i);
            ref var input = ref filter.Get3(i);

            direction = Vector2.right * input.direction.x + Vector2.up * input.direction.y;
            motion.rigidbody.velocity = direction * motion.speed * Time.deltaTime;
        }
    }
}