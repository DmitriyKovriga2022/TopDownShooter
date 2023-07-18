using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class UIEquipBodyCell : UIEquipCell
{
    public override void Show(EcsEntity entityOwner)
    {
        base.Show(entityOwner);
        InvokeRepeating(nameof(Show), Time.deltaTime, Time.deltaTime);
    }

    private void Show()
    {
        if (entityOwner.Has<EcsComponent.EquipBody>())
        {
            conteiner = new BodyConteiner(1);
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
        entityOwner.Get<EcsComponent.RemoveEqipBodyEvent>();
        Clear();
    }

    public override void SetConteiner(ItemConteiner conteiner)
    {
        if (conteiner != null)
        {
            entityOwner.Get<EcsComponent.EquippingBodyIntent>();
            Invoke(nameof(Show), Time.deltaTime);
        }
    }

    protected override void OnButton()
    {
        if (conteiner == null)
        {
            if (dragCell.Conteiner != null)
            {
                if (dragCell.Conteiner is BodyConteiner)
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

    private void OnDisable()
    {
        CancelInvoke();
    }

}