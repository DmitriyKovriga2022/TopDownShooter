using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIUseItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform layoutGropTransform;
    [SerializeField] private RectTransform infoTransform;
    [SerializeField] private Button useItemButton;
    [SerializeField] private Button dropItemButton;

    private IInventoryCellOptions cell;

    public void Initialise()
    {
        useItemButton.onClick.AddListener(OnButtonUseItem);
        dropItemButton.onClick.AddListener(OnButtonDripItem);
        Hide();
    }

    public void Show(Vector2 screenPosition, IInventoryCellOptions cell)
    {
        if (cell == null)
        {
            Debug.Log("Cell is null");
            return;
        }

        this.cell = cell;
        layoutGropTransform.position = screenPosition;
        infoTransform.position = screenPosition;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnButtonUseItem()
    {
        cell.Use();
    }

    private void OnButtonDripItem()
    {
        cell.Drop();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Hide();
    }
}
