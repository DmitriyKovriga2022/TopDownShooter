using System;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryCell : MonoBehaviour
{
    public event Action<ItemConteiner> EventSetItem;
    public event Action<ItemConteiner> EventGetItem;

    [SerializeField] private DragItem dragCell;
    private Image image;
    private Text text;
    private Button button;

    private Sprite defaultSprite;
    private ItemConteiner conteiner;

    public void Initialise()
    {
        text = GetComponentInChildren<Text>(true);
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButton);
        defaultSprite = image.sprite;
        Clear();
    }

    private void OnButton()
    {
        if (conteiner == null)
        {
            if (dragCell.Conteiner != null)
            {
                EventSetItem?.Invoke(dragCell.Conteiner);
            }
        }
        else
        {
            EventGetItem?.Invoke(conteiner);
        }
    }

    public void SetConteiner(ItemConteiner conteiner)
    {
        if(conteiner == null)
        {
            image.sprite = defaultSprite;
            text.text = "";
            return;
        }

        this.conteiner = conteiner;
        image.sprite = conteiner.GetIcon();
        text.text = conteiner.GetContent().ToString();
        if (conteiner.GetIcon() == null)
        {
            Debug.LogError("Conteiner sprite is null");
        }
    }

    public void Clear()
    {
        image.sprite = defaultSprite;
        conteiner = null;
        text.text = "";
    }

    private void OnDisable()
    {
        Clear();
    }

}
