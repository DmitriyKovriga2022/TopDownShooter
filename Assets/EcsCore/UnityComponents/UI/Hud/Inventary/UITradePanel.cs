using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITradePanel : MonoBehaviour
{
    [SerializeField] private UITradeProduct selfTradeProduct;
    [SerializeField] private UITradeProduct otherTradeProduct;

    public void Initialise()
    {
        selfTradeProduct.Initialise();
        otherTradeProduct.Initialise();
    }

    public void Hide()
    {
        selfTradeProduct.ReturnItemToBag();
        otherTradeProduct.ReturnItemToBag();
        gameObject.SetActive(false);
    }

    public void Show(EcsEntity selfEntity, EcsEntity otherEntity)
    {
        gameObject.SetActive(true);
        selfTradeProduct.Show(otherEntity);
        otherTradeProduct.Show(selfEntity);
    }

    public void OnSwap()
    {
        selfTradeProduct.SetItemToBag(otherTradeProduct.EntityOwner);
        otherTradeProduct.SetItemToBag(selfTradeProduct.EntityOwner);
        selfTradeProduct.ResetSelf();
        otherTradeProduct.ResetSelf();
    }

    public bool ProfitableExchange()
    {
        if(otherTradeProduct.CalculatePrice() <= selfTradeProduct.CalculatePrice())
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
