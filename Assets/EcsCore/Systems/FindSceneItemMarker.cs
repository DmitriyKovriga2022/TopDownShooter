using Leopotam.Ecs;
using UnityEngine;

public class FindSceneItemMarker : IEcsRunSystem
{
    private EcsWorld ecsWorld;

    public void Run()
    {
        foreach (var item in GameObject.FindObjectsOfType<UnityComponent.SceneItemMarker>())
        {
            var entity = ecsWorld.NewEntity();
            ref var component = ref entity.Get<EcsComponent.SpawnSceneItemEvent>();
            component.position = item.transform.position;
            component.conteiners = AddConteiner(item.items);
            item.DestroySelf();
        }
    }

    private ItemConteiner[] AddConteiner(UnityComponent.SceneItemMarker.Conteiner[] items)
    {
        ItemConteiner[] conteiners = new ItemConteiner[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].name == "Ammo")
            {
                conteiners[i] = new AmmoConteiner((int)items[i].count);
            }

            if (items[i].name == "MedKit")
            {
                conteiners[i] = new MedKitConteiner((int)items[i].count);
            }

            if (items[i].name == "Food")
            {
                conteiners[i] = new FoodConteiner((int)items[i].count);
            }

            if (items[i].name == "Weapon")
            {
                conteiners[i] = new WeaponConteiner((int)items[i].count);
            }

            if (items[i].name == "Jacket")
            {
                conteiners[i] = new BodyConteiner((int)items[i].count);
            }
        }

        return conteiners;
    }
}