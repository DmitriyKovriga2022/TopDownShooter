using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIBag : MonoBehaviour
{
    [SerializeField] private UIBagCell[] cells;
    [SerializeField] private DragItem dragCell;
    [SerializeField] private Button closeButton;

    private EcsEntity bagEntity;
    private EcsEntity otherEntity;
    private ItemConteiner[] conteiners;

    private void Awake()
    {
        foreach (var item in cells)
        {
            item.EventGetItem += Item_EventGetCellItem;
            item.EventSetItem += Item_EventSetCellItem;
        }
        closeButton.onClick.AddListener(Hide);
        Hide();
    }

    private void Item_EventSetCellItem(ItemConteiner value)
    {
        ref var otherBag = ref otherEntity.Get<EcsComponent.Bag>();
        otherBag.conteiners = otherBag.conteiners.Append(value).ToArray();

        conteiners = conteiners.Append(value).ToArray();

        ref var bag = ref bagEntity.Get<EcsComponent.Bag>();
        bag.conteiners = conteiners;
        Show(bagEntity, otherEntity, conteiners);
    }

    private void Item_EventGetCellItem(ItemConteiner value)
    {
        if (dragCell.Conteiner != null) return;
        dragCell.SetConteiner(value);
        ref var otherBag = ref otherEntity.Get<EcsComponent.Bag>();
        otherBag.conteiners = otherBag.conteiners.Append(value).ToArray();

        conteiners = conteiners.Where(val => val != value).ToArray();

        ref var bag = ref bagEntity.Get<EcsComponent.Bag>();
        bag.conteiners = conteiners;
        Show(bagEntity, otherEntity, conteiners);
    }

    public void Show(EcsEntity bagEntity, EcsEntity otherEntity, ItemConteiner[] conteiners)
    {
        ClearCell();
        
        this.conteiners = conteiners;
        this.bagEntity = bagEntity;
        this.otherEntity = otherEntity;

        if (cells.Length < conteiners.Length)
        {
            Debug.LogError("Cell less conteiners");
            return;
        }

        for (int i = 0; i < conteiners.Length; i++)
        {
            cells[i].SetConteiner(conteiners[i]);
        }

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        ClearCell();
        gameObject.SetActive(false);
    }

    private void ClearCell()
    {
        foreach (var item in cells)
        {
            item.Clear();
        }
    }

    private void OnDestroy()
    {
        foreach (var item in cells)
        {
            item.EventGetItem -= Item_EventGetCellItem;
            item.EventSetItem -= Item_EventSetCellItem;
        }
    }

}
