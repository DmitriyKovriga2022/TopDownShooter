using Leopotam.Ecs;

internal class EquippingHeadSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Unit, EcsComponent.EquippingHeadIntent> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            var configIndex = filter.Get2(i).configIndex;
            entity.Get<EcsComponent.EquipHead>().configIndex = configIndex;
            entity.Del<EcsComponent.EquippingHeadIntent>();
        }
    }
}