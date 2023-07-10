using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class DropToGroundWeaponSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.DropToGroundEvent, EcsComponent.Weapon> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var weaponGo = ref filter.Get2(i).weaponGo;
            weaponGo.transform.parent = null;
            weaponGo.transform.rotation = Quaternion.identity;
            weaponGo.gameObject.layer = LayerMask.NameToLayer("Item");

            CircleCollider2D collider = weaponGo.gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 1;
            collider.isTrigger = true;

            var itemGO = weaponGo.gameObject.AddComponent<UnityComponent.SceneItem>();

            itemGO.entity = filter.GetEntity(i);

            ref var item = ref itemGO.entity.Get<EcsComponent.SceneItem>();
            item.itemGo = itemGO;

            ref var bag = ref itemGO.entity.Get<EcsComponent.Bag>();
            bag.conteiners = new ItemConteiner[1]
            {
                new WeaponConteiner(1),
            };


            if (weaponGo.gameObject.TryGetComponent(out UnityComponent.LookAtPosition component))
            {
                GameObject.Destroy(component);
            }
        }
    }

}