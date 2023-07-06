using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class ProjectileHitSystem : IEcsRunSystem
{
    private StaticData config;
    private EcsFilter<EcsComponent.ProjectileHitEvent> filter;

    private Vector2 position;
    private Quaternion rotation;
    private Collider2D collider;

    public void Run()
    {
        foreach (var i in filter)
        {
            position = filter.Get1(i).Position;
            rotation = filter.Get1(i).Rotation;
            collider = filter.Get1(i).Collider;

            Object.Instantiate(config.projectileSetting.hitEffectPrefab, position, rotation);

            Debug.Log("Hit Collider = " + collider);

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
                if(collider.TryGetComponent(out UnityComponent.Unit unit))
                {
                    int rnd = Random.Range(0, config.unitData.sound.hit.Length);
                    SoundController.PlayClipAtPosition(config.unitData.sound.hit[rnd], position);

                    //rnd = Random.Range(0, config.projectileSetting.sound.groundHit.Length);
                    //SoundController.PlayClipAtPosition(config.projectileSetting.sound.groundHit[rnd], position);
                    
                }
            }

        }
    }

}