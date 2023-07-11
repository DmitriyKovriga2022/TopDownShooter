using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class UIInventoryPanel : MonoBehaviour
{
    [SerializeField] private UIBag uiSelfBag;
    [SerializeField] private UIBag uiOtherBag;
    [SerializeField] private DragItem dragCell;

    private EcsWorld ecsWorld;

    private void Awake()
    {
        uiSelfBag.Initialise();
        uiSelfBag.EventOnHideBag += UiSelfBag_EventIntentHideBag;
        uiOtherBag.Initialise();
        uiOtherBag.EventOnHideBag += UiSelfBag_EventIntentHideBag;
        dragCell.Initialise();
        Hide();
    }

    private void UiSelfBag_EventIntentHideBag()
    {
        if (uiSelfBag.gameObject.activeSelf == false &&
           uiOtherBag.gameObject.activeSelf == false)
        {
            dragCell.ReturnToBag();
            dragCell.Clear();
            gameObject.SetActive(false);
        }
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
        dragCell.ReturnToBag();
        dragCell.Clear();
        gameObject.SetActive(false);
    }

}