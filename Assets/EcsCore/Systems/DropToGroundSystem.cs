using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class DropToGroundSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.DropToGroundEvent, EcsComponent.Weapon> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var weaponGo = ref filter.Get2(i).weaponGo;
            weaponGo.transform.parent = null;
            if (weaponGo.gameObject.TryGetComponent(out UnityComponent.LookAtPosition component))
            {
                GameObject.Destroy(component);
            }
        }
    }

}