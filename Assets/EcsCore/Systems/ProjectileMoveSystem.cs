using Leopotam.Ecs;
using UnityEngine;
internal class ProjectileMoveSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private EcsFilter<EcsComponent.Projectile, EcsComponent.ProjectileMotion> filter;

    private float speed;
    private Transform transform;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var projectile = ref filter.Get2(i);
            speed = projectile.Speed;
            transform = projectile.Transform;

            transform.LookAt2D(transform.right, (Vector2)transform.position + projectile.Direction);

            if (RaycastHit(transform, speed, out Vector3 hitPosition))
            {
                Hit(hitPosition, transform.rotation);
                filter.Get1(i).gameObject.DestroySelf();
                filter.GetEntity(i).Destroy();
            }
            else
            {
                if (projectile.MaxDistance < projectile.CurrentDistance)
                {
                    Hit(transform.position, transform.rotation);
                    filter.Get1(i).gameObject.DestroySelf();
                    filter.GetEntity(i).Destroy();
                }
                else
                {
                    transform.position += transform.right * speed;
                    projectile.CurrentDistance += (transform.right * speed).magnitude;
                }
            }
        }
    }

    private void Hit(Vector2 position, Quaternion rotation)
    {
        var entity = ecsWorld.NewEntity();
        ref var hitEvent = ref entity.Get<EcsComponent.ProjectileHitEvent>();
        hitEvent.Position = position;
        hitEvent.Rotation = rotation;
    }

    private bool RaycastHit(Transform transform, float speed, out Vector3 hitPosition)
    {
        hitPosition = Vector3.zero;
        float distance = (transform.right * speed).magnitude;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * speed, distance);
        if (hit.collider != null)
        {
            hitPosition = hit.point;
            return true;
        }

        return false;
    }
}
