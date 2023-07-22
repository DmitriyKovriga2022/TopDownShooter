using Leopotam.Ecs;
using System.Linq;

public class ShiftEquipWeaponMainToBagSystem : IEcsRunSystem
    {
        private EcsFilter<EcsComponent.ShiftWeaponMainToBagEvent, EcsComponent.EquipWeaponMain, EcsComponent.Bag> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var item = ref filter.Get2(i);
                ItemConteiner conteiner = new WeaponConteiner(item.configIndex, item.wearout);
                ref var bag = ref filter.Get3(i);
                bag.conteiners = bag.conteiners.Append(conteiner).ToArray();
            }
        }
    }