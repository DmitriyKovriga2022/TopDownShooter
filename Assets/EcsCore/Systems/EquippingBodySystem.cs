using Leopotam.Ecs;

public class EquippingBodySystem : IEcsRunSystem
{
    private Hud hud;
    private StaticData config;
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingBodyIntent, EcsComponent.Armor> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);

            ref var configIndex = ref filter.Get2(i).configIndex;
            entity.Get<EcsComponent.EquipBody>().configIndex = configIndex;

            ref var armor = ref filter.Get3(i).value;
            armor += ItemData.Instance.Body[configIndex].ArmorValue;

            if (entity.Has<EcsComponent.Player>())
            {
                hud.HudArmor.ShowArmor(armor, 100);
            }

            entity.Del<EcsComponent.EquippingBodyIntent>();
        }
    }
}