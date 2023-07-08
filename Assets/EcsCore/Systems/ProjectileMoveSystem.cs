using Leopotam.Ecs;
using UnityEngine;
internal class ProjectileMoveSystem : IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private StaticData config;
    private EcsFilter<EcsComponent.Projectile, EcsComponent.ProjectileMotion> filter;

    private float speed;
    private Transform transform;
    private float power;
    private LayerMask mask;

    public void Run()
    {
        mask = config.projectileSetting.hitMask;
        foreach (var i in filter)
        {
            ref var projectile = ref filter.Get1(i);
            power = projectile.power;

            ref var motion = ref filter.Get2(i);
            speed = motion.Speed;
            transform = motion.Transform;

            transform.LookAt2D(transform.right, (Vector2)transform.position + motion.Direction);

            if (RaycastHit(transform, speed, out HitInfo hitInfo))
            {
                Hit(hitInfo, transform.rotation);
                filter.Get1(i).gameObject.DestroySelf();
                filter.GetEntity(i).Destroy();
            }
            else
            {
                if (motion.MaxDistance < motion.CurrentDistance)
                {
                    Hit(transform.position, transform.rotation);
                    filter.Get1(i).gameObject.DestroySelf();
                    filter.GetEntity(i).Destroy();
                }
                else
                {
                    transform.position += transform.right * speed;
                    motion.CurrentDistance += (transform.right * speed).magnitude;
                }
            }
        }
    }

    private void Hit(Vector2 position, Quaternion rotation)
    {
        var entity = ecsWorld.NewEntity();
        ref var hitEvent = ref entity.Get<EcsComponent.ProjectileHitEvent>();
        hitEvent.power = power;
        hitEvent.Position = position;
        hitEvent.Rotation = rotation;
        hitEvent.Collider = null;
    }

    private void Hit(HitInfo hitInfo, Quaternion rotation)
    {
        var entity = ecsWorld.NewEntity();
        ref var hitEvent = ref entity.Get<EcsComponent.ProjectileHitEvent>();
        hitEvent.power = power;
        hitEvent.Position = hitInfo.hitPosition;
        hitEvent.Rotation = rotation;
        hitEvent.Collider = hitInfo.hitCollider;
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

    private bool RaycastHit(Transform transform, float speed, out HitInfo hitInfo)
    {
        hitInfo = new HitInfo();
        float distance = (transform.right * speed).magnitude;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * speed, distance, mask);
        if (hit.collider != null)
        {
            hitInfo.hitCollider = hit.collider;
            hitInfo.hitPosition = hit.point;
            return true;
        }

        return false;
    }

    public class HitInfo
    {
        public Collider2D hitCollider;
        public Vector2 hitPosition;
    }

}
