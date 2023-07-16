using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class ProjectileHitSystem : IEcsRunSystem
{
    private StaticData config;
    private EcsFilter<EcsComponent.ProjectileHitEvent> filter;

    private float power;
    private Vector2 position;
    private Quaternion rotation;
    private Collider2D collider;

    public void Run()
    {
        foreach (var i in filter)
        {
            power = filter.Get1(i).power;
            position = filter.Get1(i).Position;
            rotation = filter.Get1(i).Rotation;
            collider = filter.Get1(i).Collider;

            Object.Instantiate(config.projectileSetting.hitEffectPrefab, position, rotation);

            if (collider == null)
            {
                int rnd = Random.Range(0, config.projectileSetting.sound.groundHit.Length);
                SoundController.PlayClipAtPosition(config.projectileSetting.sound.groundHit[rnd], position);

                if (Random.Range(0, 2) == 0)
                {
                    rnd = Random.Range(0, config.projectileSetting.sound.groundRicochet.Length);
                    SoundController.PlayClipAtPosition(config.projectileSetting.sound.groundRicochet[rnd], position);
                }
            }
            else
            {
                if(collider.TryGetComponent(out UnityComponent.HitHandler handler))
                {
                    handler.entity.Get<EcsComponent.HitBulletEvent>().hitPower = power;
                    Debug.Log("Hit ");
                }
            }

        }
    }

}