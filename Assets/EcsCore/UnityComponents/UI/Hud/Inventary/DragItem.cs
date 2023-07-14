using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DragItem : MonoBehaviour
{
    [SerializeField] private Image image;
    public ItemConteiner Conteiner => conteiner;
    private ItemConteiner conteiner;
    public EcsEntity Entity => entity;
    private EcsEntity entity;
    private Sprite defaultSprite;

    public void Initialise()
    {
        defaultSprite = image.sprite;
    }

    public void SetConteiner(ItemConteiner conteiner, EcsEntity entity)
    {
        if (conteiner == null)
        {
            image.sprite = defaultSprite;
            return;
        }

        this.conteiner = conteiner;
        this.entity = entity;
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

    public void ReturnItemToBag()
    {
        if (conteiner == null) return;
        ref var bagConteiner = ref entity.Get<EcsComponent.Bag>().conteiners;
        bagConteiner = bagConteiner.Append(conteiner).ToArray();
    }

    private void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }

}
