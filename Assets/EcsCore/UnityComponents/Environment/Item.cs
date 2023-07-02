using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : SceneObject, IGameObject
{
    public EcsEntity entity;

    public void OnCollisionUnit(EcsEntity otherEntity)
    {
        entity.Get<EcsComponent.ItemCollisionEvent>().otherEntity = otherEntity;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
