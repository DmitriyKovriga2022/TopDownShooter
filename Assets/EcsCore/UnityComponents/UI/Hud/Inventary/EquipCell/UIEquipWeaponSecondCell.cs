using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class UIEquipWeaponSecondCell : UIEquipCell
{
    public override void Show(EcsEntity entityOwner)
    {
        base.Show(entityOwner);
        Show();
    }

    private void Show()
    {
        if (entityOwner.Has<EcsComponent.EquipWeaponSecond>())
        {
            conteiner = new WeaponConteiner(1);
            image.sprite = conteiner.GetIcon();

            if (conteiner.GetIcon() == null)
            {
                Debug.LogError("Conteiner sprite is null");
            }
        }
        else
        {
            image.sprite = defaultSprite;
        }
    }

    public override void GetConteiner()
    {
        if (dragCell.Conteiner != null) return;
        dragCell.SetConteiner(conteiner, entityOwner);
        entityOwner.Get<EcsComponent.RemoveEqipSecondWeaponEvent>();
        Clear();
    }

    public override void SetConteiner(ItemConteiner conteiner)
    {
        if (conteiner != null)
        {
            entityOwner.Get<EcsComponent.EquippingWeaponSecondIntent>();
            Invoke(nameof(Show), Time.deltaTime);
        }
    }

    protected override void OnButton()
    {
        if (conteiner == null)
        {
            if (dragCell.Conteiner != null)
            {
                if (dragCell.Conteiner is WeaponConteiner)
                {
                    SetConteiner(dragCell.Conteiner);
                    dragCell.Clear();
                }
            }
        }
        else
        {
            GetConteiner();
        }
    }
}