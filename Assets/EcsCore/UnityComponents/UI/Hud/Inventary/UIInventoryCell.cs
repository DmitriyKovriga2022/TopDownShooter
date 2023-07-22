using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public interface IInventoryCellOptions
{
    public void Use();
    public void Drop();
}

public class UIInventoryCell : MonoBehaviour, IPointerClickHandler, IInventoryCellOptions
{
    public event Action<ItemConteiner> EventSetItem;
    public event Action<ItemConteiner> EventGetItem;
    public event Action<ItemConteiner> EventUseItem;
    public event Action<ItemConteiner> EventDropItem;
    public event Action<Vector2, IInventoryCellOptions> EventGetItemMenu;

    [SerializeField] private DragItem dragCell;
    private Image image;
    private Text text;
    private Button button;

    private Sprite defaultSprite;
    private ItemConteiner conteiner;
    private bool isInitialise = false;

    public void Initialise()
    {
        text = GetComponentInChildren<Text>(true);
        image = GetComponent<Image>();
        //button = GetComponent<Button>();
        //button.onClick.AddListener(OnButton);
        defaultSprite = image.sprite;
        isInitialise = true;
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
        text.text = conteiner.GetCount().ToString();
        if (conteiner.GetIcon() == null)
        {
            Debug.LogError("Conteiner sprite is null");
        }
    }

    public void Clear()
    {
        if (isInitialise == false)
        {
            Initialise();
        }
        else
        {
            image.sprite = defaultSprite;
            conteiner = null;
            text.text = "";
        }
    }

    private void OnDisable()
    {
        Clear();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (conteiner == null) return;
            EventGetItemMenu?.Invoke((transform as RectTransform).position, this as IInventoryCellOptions);
        }
        else
        {
            OnButton();
        }
    }

    public void Use()
    {
        if (conteiner == null) return;

        EventUseItem?.Invoke(conteiner);
    }

    public void Drop()
    {
        EventDropItem?.Invoke(conteiner);
    }
}
