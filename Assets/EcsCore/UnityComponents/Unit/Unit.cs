using Leopotam.Ecs;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public EcsEntity entity;
    public new Rigidbody2D rigidbody;
    public Transform mainTransform;
    public Transform visualTransform;

    [SerializeField] private Bag bag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Item item))
        {
            item.OnCollisionUnit(entity);
        }
    }
}
