using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWearoutImageHandler : MonoBehaviour
{
    [SerializeField] private RectTransform wearoutTransform;
    [SerializeField] private Image wearoutImage;
    private float wearoutImageSize;
    private UIEquipCell.IShowContent showContent;

    private void Start()
    {
        wearoutImageSize = wearoutTransform.sizeDelta.y;
        showContent = GetComponentInParent<UIEquipCell.IShowContent>();
        showContent.EventShowContent += ShowContent_EventShowContent;
        showContent.EventClearContent += ShowContent_EventClearContent;
        wearoutTransform.sizeDelta = new Vector2(wearoutTransform.sizeDelta.x, -100);
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
        float sizeY = 100 - value;
        wearoutTransform.sizeDelta = new Vector2(wearoutTransform.sizeDelta.x, -sizeY);

        float r = value;
        float g = 1 - value;
        float b = 0;

        wearoutImage.color = new Color(r, g, b);
    }

    private void HideWearout()
    {
       wearoutTransform.sizeDelta = new Vector2(wearoutTransform.sizeDelta.x, 0);
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
