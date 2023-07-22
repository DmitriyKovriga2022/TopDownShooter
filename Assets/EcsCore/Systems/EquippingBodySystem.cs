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
            if(entity.Has<EcsComponent.EquipBody>())
            {
                entity.Get<EcsComponent.ShiftBodyToBagEvent>();
                continue;
            }

            ref var equipBody = ref entity.Get<EcsComponent.EquipBody>();
            equipBody.configIndex = filter.Get2(i).configIndex;
            equipBody.wearout = filter.Get2(i).wearout;

            ref var armor = ref filter.Get3(i).value;
            armor += ItemData.Instance.Body[equipBody.configIndex].ArmorValue;
            if (entity.Has<EcsComponent.Player>())
            {
                hud.HudArmor.ShowArmor(armor, 100);
            }

            entity.Del<EcsComponent.EquippingBodyIntent>();
        }
    }
}