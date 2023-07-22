using Leopotam.Ecs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipHeadCell : UIEquipCell, UIEquipCell.IShowContent
{
    public event Action<ItemConteiner> EventShowContent;
    public event Action EventClearContent;

    public override void Show(EcsEntity entityOwner)
    {
        base.Show(entityOwner);
        InvokeRepeating(nameof(Show), Time.deltaTime, Time.deltaTime);
    }

    private void Show()
    {
        if (entityOwner.Has<EcsComponent.EquipHead>())
        {
            conteiner = new HeadConteiner(entityOwner.Get<EcsComponent.EquipHead>().configIndex);
            image.sprite = conteiner.GetIcon();

            if (conteiner.GetIcon() == null)
            {
                Debug.LogError("Conteiner sprite is null");
            }

            EventShowContent?.Invoke(conteiner);
        }
        else
        {
            image.sprite = defaultSprite;
            EventClearContent?.Invoke();
        }
    }

    public override void GetConteiner()
    {
        if (dragCell.Conteiner != null) return;
        dragCell.SetConteiner(conteiner, entityOwner);
        entityOwner.Get<EcsComponent.RemoveEqipHeadEvent>();
        Clear();
    }

    public override void SetConteiner(ItemConteiner conteiner)
    {
        if (conteiner != null)
        {
            ref var body = ref entityOwner.Get<EcsComponent.EquippingHeadIntent>();
            body.configIndex = conteiner.GetConfigId();
            Invoke(nameof(Show), Time.deltaTime);
        }
    }

    protected override void OnButton()
    {
        if (conteiner == null)
        {
            if (dragCell.Conteiner != null)
            {
                if (dragCell.Conteiner is HeadConteiner)
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