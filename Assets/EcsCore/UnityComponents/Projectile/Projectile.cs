using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IGameObject
{
    [SerializeField] private GameObject hitPrefab;
    public Transform Transform => transform;
    [SerializeField] new Transform transform;
    public float Speed => speed;
    [SerializeField] private float speed;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    //public void Shoot()
    //{
    //    targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    direction = targetPosition - (Vector2)transform.position;
    //}

    //private void Update()
    //{
    //    transform.LookAt2D(transform.right, (Vector2)transform.position + direction);

    //    if (Hit(out Vector3 hitPosition))
    //    {
    //        Instantiate(hitPrefab, hitPosition, transform.rotation);
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        float moveDistance = (transform.right * speed).magnitude;
    //        float targetDistance = (targetPosition - (Vector2)transform.position).magnitude;
    //        if (targetDistance < moveDistance)
    //        {
    //            transform.position = targetPosition;
    //            Instantiate(hitPrefab, targetPosition, transform.rotation);
    //            Destroy(gameObject);
    //        }
    //        else
    //        {
    //            transform.position += transform.right * speed;
    //        }
    //    }

    //}

    //private bool Hit(out Vector3 hitPosition)
    //{
    //    hitPosition = Vector3.zero;
    //    float distance = (transform.right * speed).magnitude;
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * speed, distance);
    //    if(hit.collider != null)
    //    {
    //        hitPosition = hit.point;
    //        return true;
    //    }

    //    return false;
    //}

}
