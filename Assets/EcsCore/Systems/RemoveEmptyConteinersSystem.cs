using Leopotam.Ecs;
using System.Linq;

public class RemoveEmptyConteinersSystem : IEcsRunSystem
{
    private EcsFilter<EcsComponent.Bag> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            var entity = filter.GetEntity(i);
            ref var conteiners = ref filter.Get1(i).conteiners;
            if (conteiners == null)
            {
                Debug.LogError("Entity " + entity.GetInternalId() + ": Conteiners is null");
                continue;
            }

            if (conteiners.Length > 0)
            {
                conteiners = conteiners.Where(x => x.GetCount() != 0).ToArray();
            }
        } 
    }
}