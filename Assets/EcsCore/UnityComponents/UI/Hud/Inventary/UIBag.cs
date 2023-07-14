using Leopotam.Ecs;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIBag : MonoBehaviour
{
    public event Action EventOnHideBag;
    [SerializeField] private UIInventoryCell[] cells;
    [SerializeField] private DragItem dragCell;

    private EcsEntity entityOwner;
    private ItemConteiner[] conteiners;
    private UIInventoryPanel inventoryPanel;

    public void Initialise(UIInventoryPanel inventoryPanel)
    {
        this.inventoryPanel = inventoryPanel;
        foreach (var item in cells)
        {
            item.Initialise();
            item.EventGetItem += Item_EventGetCellItem;
            item.EventSetItem += Item_EventSetCellItem;
        }
    }

    private void Item_EventSetCellItem(ItemConteiner value)
    {
        if(inventoryPanel.IsTradeState)
        {
            if (dragCell.Entity != entityOwner) return;
        }

        conteiners = conteiners.Append(value).ToArray();
        if (entityOwner.Has<EcsComponent.Bag>())
        {
            entityOwner.Get<EcsComponent.Bag>().conteiners = conteiners;
        }

        dragCell.Clear();
        Show(entityOwner);
    }

    private void Item_EventGetCellItem(ItemConteiner value)
    {
        if (dragCell.Conteiner != null) return;
        dragCell.SetConteiner(value, entityOwner);

        conteiners = conteiners.Where(val => val != value).ToArray();

        if (entityOwner.Has<EcsComponent.Bag>())
        {
            entityOwner.Get<EcsComponent.Bag>().conteiners = conteiners;
        }

        Show(entityOwner);
    }

    public void Show(EcsEntity bagEntity)
    {
        ClearCell();

        entityOwner = bagEntity;

        if (entityOwner.Has<EcsComponent.Bag>())
        {
            conteiners = entityOwner.Get<EcsComponent.Bag>().conteiners;
        }

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

    public void ReShow()
    {
        Show(entityOwner);
    }

    public void Hide()
    {
        ClearCell();
        gameObject.SetActive(false);
        EventOnHideBag?.Invoke();
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
