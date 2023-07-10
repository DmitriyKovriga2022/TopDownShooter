using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class UIInventoryPanel : MonoBehaviour
{
    [SerializeField] private UIBag uiSelfBag;
    [SerializeField] private UIBag uiOtherBag;
    [SerializeField] private DragItem dragCell;

    private void Awake()
    {
        uiSelfBag.Initialise();
        uiOtherBag.Initialise();
        dragCell.Initialise();
        Hide();
    }

    public void ShowSelfBag(EcsEntity bagEntity, ItemConteiner[] conteiners)
    {
        uiSelfBag.Show(bagEntity, conteiners);
        gameObject.SetActive(true);
    }
    
    public void ShowOtherBag(EcsEntity bagEntity, ItemConteiner[] conteiners)
    {
        uiOtherBag.Show(bagEntity, conteiners);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        uiSelfBag.Hide();
        uiOtherBag.Hide();
        dragCell.DropToGroundItem();
        gameObject.SetActive(false);
    }

}