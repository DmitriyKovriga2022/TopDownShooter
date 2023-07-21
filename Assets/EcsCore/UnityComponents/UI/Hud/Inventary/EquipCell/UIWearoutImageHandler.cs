using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWearoutImageHandler : MonoBehaviour
{
    [SerializeField] private RectTransform wearoutTtransform;
    private float wearoutImageSize;
    private UIEquipCell.IShowContent showContent;

    private void Start()
    {
        wearoutImageSize = wearoutTtransform.sizeDelta.y;
        showContent = GetComponentInParent<UIEquipCell.IShowContent>();
        showContent.EventShowContent += ShowContent_EventShowContent;
        showContent.EventClearContent += ShowContent_EventClearContent;
    }

    private void ShowContent_EventClearContent()
    {
        HideWearout();
    }

    private void ShowContent_EventShowContent(ItemConteiner value)
    {
        ShowWearout(value.GetWearout());
    }

    private void ShowWearout(float value)
    {
        float sizeY = wearoutImageSize / 100 * value;
        wearoutTtransform.sizeDelta = new Vector2(wearoutTtransform.sizeDelta.x, sizeY);
    }

    private void HideWearout()
    {
       wearoutTtransform.sizeDelta = new Vector2(wearoutTtransform.sizeDelta.x, 0);
    }

    private void OnDestroy()
    {
        if (showContent != null)
        {
            showContent.EventShowContent -= ShowContent_EventShowContent;
            showContent.EventClearContent -= ShowContent_EventClearContent;
        }
    }

}
