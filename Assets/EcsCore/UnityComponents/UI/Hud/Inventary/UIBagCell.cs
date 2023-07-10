using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBagCell : MonoBehaviour
{
    public event Action<ItemConteiner> EventSetItem;
    public event Action<ItemConteiner> EventGetItem;

    [SerializeField] private DragItem dragCell;

    private Image image;
    private Button button;
    private Sprite defaultSprite;
    private ItemConteiner conteiner;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButton);
        defaultSprite = image.sprite;
        Clear();
    }

    private void OnButton()
    {
        if (conteiner == null)
        {
            if (dragCell.Conteiner != null)
            {
                EventSetItem?.Invoke(dragCell.Conteiner);
                dragCell.Clear();
            }
        }
        else
        {
            EventGetItem?.Invoke(conteiner);
        }
    }

    public void SetConteiner(ItemConteiner conteiner)
    {
        if(conteiner == null)
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
