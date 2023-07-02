using Leopotam.Ecs;
using UnityEngine;

internal class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Player, EcsComponent.UnitMotion, EcsComponent.DesiredMoveDirection> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var player = ref filter.Get1(i);
            ref var motion = ref filter.Get2(i);
            ref var input = ref filter.Get3(i);

            Vector3 direction = new Vector2(input.direction.x, input.direction.z).normalized;
            //motion.rigidbody.velocity = direction * motion.speed;
            //motion.rigidbody.MovePosition(player.transform.position + (direction * motion.speed));
            motion.rigidbody.transform.position += (direction * motion.speed);
        }
    }
}