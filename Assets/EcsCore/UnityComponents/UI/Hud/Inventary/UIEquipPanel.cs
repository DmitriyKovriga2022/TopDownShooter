using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEquipPanel : MonoBehaviour
{
    [SerializeField] private DragItem dragCell;
    [SerializeField] private UIEquipCell[] equipCells;

    public void Initialise()
    {
        foreach (var item in equipCells)
        {
            item.Initialise(dragCell);
        }
    }

    internal void Show(EcsEntity selfEntity)
    {
        foreach (var item in equipCells)
        {
            item.Show(selfEntity);
        }

        gameObject.SetActive(true);
    }

    internal void Hide()
    {
        gameObject.SetActive(false);
    }
}
