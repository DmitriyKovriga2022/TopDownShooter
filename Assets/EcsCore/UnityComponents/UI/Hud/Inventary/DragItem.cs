using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragItem : MonoBehaviour
{
    [SerializeField] private EcsWorld ecsWorld;
    [SerializeField] private Image image;
    private Sprite defaultSprite;
    public ItemConteiner Conteiner => conteiner;
    private ItemConteiner conteiner;
    

    public void Initialise()
    {
        defaultSprite = image.sprite;
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

    public void DropToGroundItem()
    {
        if (conteiner == null) return;
        var entity = ecsWorld.NewEntity();
        ref var bag = ref entity.Get<EcsComponent.Bag>();
        bag.conteiners = new ItemConteiner[1];
        bag.conteiners[0] = conteiner;
        entity.Get<EcsComponent.DropToGroundEvent>().position = (Vector2)Camera.main.transform.position;

    }

    private void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }

}
