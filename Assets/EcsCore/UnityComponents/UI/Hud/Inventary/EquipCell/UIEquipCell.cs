using Leopotam.Ecs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipCell : MonoBehaviour
{
    public interface IShowContent
    {
        public event Action<ItemConteiner> EventShowContent;
        public event Action EventClearContent;
    }

    protected DragItem dragCell;
    protected Image image;
    private Button button;

    protected Sprite defaultSprite;
    protected ItemConteiner conteiner;

    protected EcsEntity entityOwner;

    public virtual void Initialise(DragItem dragCell)
    {
        this.dragCell = dragCell;
        image = transform.GetChild(0).GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButton);
        defaultSprite = image.sprite;
        Clear();
    }

    public virtual void Show(EcsEntity entityOwner)
    {
        this.entityOwner = entityOwner;
    }

    protected virtual void OnButton()
    {
        if (conteiner == null)
        {
            if (dragCell.Conteiner != null)
            {
                SetConteiner(dragCell.Conteiner);
                dragCell.Clear();
            }
        }
        else
        {
            GetConteiner();
        }
    }

    public virtual void SetConteiner(ItemConteiner conteiner)
    {
        if (conteiner == null)
        {
            image.sprite = defaultSprite;
            return;
        }

        this.conteiner = conteiner;
        image.sprite = conteiner.GetIcon();

        if (conteiner.GetIcon() == null)
        {
            Debug.LogError("Conteiner sprite is null");
        }
    }

    public virtual void GetConteiner()
    {
        if (dragCell.Conteiner != null) return;
        dragCell.SetConteiner(conteiner, entityOwner);
        Clear();
    }

    public void Clear()
    {
        image.sprite = defaultSprite;
        conteiner = null;
    }

    private void OnDisable()
    {
        Clear();
    }

    
}