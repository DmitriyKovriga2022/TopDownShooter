using Leopotam.Ecs;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ShiftEquipWeaponSecondToBagSystem : IEcsRunSystem
    {
        private EcsFilter<EcsComponent.ShiftWeaponSecondToBagEvent, EcsComponent.EquipWeaponSecond, EcsComponent.Bag> filter;

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