using Leopotam.Ecs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryPanel : MonoBehaviour
{
    [SerializeField] private UIBag uiSelfBag;
    [SerializeField] private UIBag uiOtherBag;
    [SerializeField] private UITradePanel uiTradePanel;
    [SerializeField] private UIEquipPanel uiEquipPanel;
    [SerializeField] private DragItem dragCell;
    [SerializeField] private Button swapButton;
    [SerializeField] private Button closeButton;

    public void Initialise()
    {
        uiSelfBag.Initialise(this);
        uiSelfBag.EventOnHideBag += UiSelfBag_EventIntentHideBag;
        uiOtherBag.Initialise(this);
        uiOtherBag.EventOnHideBag += UiSelfBag_EventIntentHideBag;
        dragCell.Initialise();
        uiTradePanel.Initialise();
        uiEquipPanel.Initialise();
        swapButton.onClick.AddListener(OnSwap);
        closeButton.onClick.AddListener(OnButtonClose);
        Hide();
    }

    private void OnSwap()
    {
        if (dragCell.Conteiner != null) return;

        if (uiTradePanel.ProfitableExchange() == false) return;

        uiTradePanel.OnSwap();
        uiSelfBag.ReShow();
        uiOtherBag.ReShow();
    }

    private void UiSelfBag_EventIntentHideBag()
    {
        if (uiSelfBag.gameObject.activeSelf == false &&
            uiOtherBag.gameObject.activeSelf == false)
        {
            dragCell.ReturnItemToBag();
            dragCell.Clear();
            gameObject.SetActive(false);
        }
    }

    public void ShowSelfBag(EcsEntity bagEntity)
    {
        uiSelfBag.Show(bagEntity);
        gameObject.SetActive(true);
    }
    
    public void ShowOtherBag(EcsEntity bagEntity)
    {
        uiOtherBag.Show(bagEntity);
        gameObject.SetActive(true);
    }

    public void ShowTradeBag(EcsEntity bagEntity, EcsEntity otherEntity)
    {
        uiOtherBag.Show(bagEntity);
        uiTradePanel.Show(bagEntity, otherEntity);
        gameObject.SetActive(true);
    }

    public void ShowEquipPanel(EcsEntity selfEntity)
    {
        uiEquipPanel.Show(selfEntity);
        gameObject.SetActive(true);
    }

    public bool IsTradeState
    {
        get
        {
            return uiTradePanel.gameObject.activeSelf;
        }
    }

    private void OnButtonClose()
    {
        if (dragCell.Conteiner != null) return;
        Hide();
    }

    public void Hide()
    {
        uiSelfBag.Hide();
        uiOtherBag.Hide();
        uiTradePanel.Hide();
        uiEquipPanel.Hide();
        dragCell.ReturnItemToBag();
        dragCell.Clear();
        gameObject.SetActive(false);
    }

}