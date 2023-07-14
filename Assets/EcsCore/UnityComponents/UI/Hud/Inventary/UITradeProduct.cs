using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UITradeProduct : MonoBehaviour
{
    [SerializeField] private Text selfPrice;
    [SerializeField] private DragItem dragCell;
    [SerializeField] private UIInventoryCell[] cells;

    public EcsEntity EntityOwner => entityOwner;
    private EcsEntity entityOwner;

    private ItemConteiner[] conteiners;

    public void Initialise()
    {
        foreach (var item in cells)
        {
            item.Initialise();
            item.EventGetItem += Item_EventGetCellItem;
            item.EventSetItem += Item_EventSetCellItem;
        }

        conteiners = new ItemConteiner[0];
        CalculatePrice();
    }

    private void Item_EventSetCellItem(ItemConteiner value)
    {
        if (dragCell.Entity != entityOwner) return;
        conteiners = conteiners.Append(value).ToArray();
        for (int i = 0; i < cells.Length; i++)
        {
            if (conteiners.Length > i)
            {
                cells[i].SetConteiner(conteiners[i]);
            }
            else
            {
                cells[i].Clear();
            }
        }
        dragCell.Clear();
        CalculatePrice();
    }

    private void Item_EventGetCellItem(ItemConteiner value)
    {
        if (dragCell.Conteiner != null) return;
        dragCell.SetConteiner(value, entityOwner);

        conteiners = conteiners.Where(val => val != value).ToArray();
        for (int i = 0; i < cells.Length; i++)
        {
            if (conteiners.Length > i)
            {
                cells[i].SetConteiner(conteiners[i]);
            }
            else
            {
                cells[i].Clear();
            }
        }
        CalculatePrice();
    }

    public int CalculatePrice()
    {
        int price = 0;

        for (int i = 0; i < conteiners.Length; i++)
        {
            price += conteiners[i].GetPrice();
        }

        selfPrice.text = price.ToString();
        return price;
    }

    public void Show(EcsEntity entityOwner)
    {
        ResetSelf();
        this.entityOwner = entityOwner;
    }

    public void ReturnItemToBag()
    {
        if (conteiners.Length == 0)
        {
            return;
        }

        SetItemToBag(entityOwner);
    }

    public void SetItemToBag(EcsEntity entityTarget)
    {
        ref var bagConteiner = ref entityTarget.Get<EcsComponent.Bag>().conteiners;
        foreach (var item in conteiners)
        {
            bagConteiner = bagConteiner.Append(item).ToArray();
        }
    }

    public void ResetSelf()
    {
        foreach (var item in cells)
        {
            item.Clear();
        }
        conteiners = new ItemConteiner[0];
        CalculatePrice();
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
