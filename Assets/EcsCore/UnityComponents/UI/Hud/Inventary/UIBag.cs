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
    [SerializeField] private UIUseItem useItem;

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
            item.EventGetItemMenu += Item_EventGetItemMenu;
            item.EventUseItem += Item_EventUseItem;
            item.EventDropItem += Item_EventDropItem;
        }
    }

    private void Item_EventDropItem(ItemConteiner conteiner)
    {
        conteiner.Drop(entityOwner);
        RemoveConteiner(conteiner);
        HideUseItemPanel();
        ReShow();
    }

    private void Item_EventUseItem(ItemConteiner conteiner)
    {
        conteiner.Apply(entityOwner);
        RemoveConteiner(conteiner);
        HideUseItemPanel();
    }

    private void Item_EventGetItemMenu(Vector2 screenPosition, IInventoryCellOptions cell)
    {
        useItem.Show(screenPosition, cell);
    }

    private void HideUseItemPanel()
    {
        useItem.Hide();
    }

    private void Item_EventSetCellItem(ItemConteiner conteiner)
    {
        if(inventoryPanel.IsTradeState)
        {
            if (dragCell.Entity != entityOwner) return;
        }

        //Debug.Log("Item wearout= " + conteiner.GetWearout());
        conteiners = conteiners.Append(conteiner).ToArray();
        if (entityOwner.Has<EcsComponent.Bag>())
        {
            entityOwner.Get<EcsComponent.Bag>().conteiners = conteiners;
        }

        dragCell.Clear();
        ReShow();
    }

    private void Item_EventGetCellItem(ItemConteiner conteiner)
    {
        if (dragCell.Conteiner != null) return;
        
        dragCell.SetConteiner(conteiner, entityOwner);

        RemoveConteiner(conteiner);
    }

    private void RemoveConteiner(ItemConteiner value)
    {
        conteiners = conteiners.Where(val => val != value).ToArray();

        if (entityOwner.Has<EcsComponent.Bag>())
        {
            entityOwner.Get<EcsComponent.Bag>().conteiners = conteiners;
        }

        ReShow();
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
