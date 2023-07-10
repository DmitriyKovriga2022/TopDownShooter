using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragItem : MonoBehaviour
{
    private Image image;
    private Sprite defaultSprite;
    public ItemConteiner Conteiner => conteiner;
    private ItemConteiner conteiner;

    private void Awake()
    {
        image = GetComponent<Image>();
        defaultSprite = image.sprite;
        Clear();
    }

    public void SetConteiner(ItemConteiner conteiner)
    {
        if (conteiner == null)
        {
            image.sprite = defaultSprite;
            return;
        }

        this.conteiner = conteiner;
        image.sprite = conteiner.GetIcon();

        if (conteiner.GetIcon() == null)
        {
            Debug.LogError("Conteiner sprite is null");
        }

        gameObject.SetActive(true);
    }

    public void Clear()
    {
        conteiner = null;
        image.sprite = defaultSprite;
        gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }

}
