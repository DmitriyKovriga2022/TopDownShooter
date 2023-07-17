using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiCombat : MonoBehaviour
{
    private Vector2 moveTargetPoint;
    private UnityComponent.Unit mainTarget;
    private UnityComponent.Unit currentTarget;
    private Ai ai;
    private int layerMask;
    private LookAt lookAt;

    public void Initialise(Ai ai)
    {
        this.ai = ai;
        layerMask = 1 << LayerMask.NameToLayer("Default");
        lookAt = GetComponentInParent<LookAt>();
        DisableSelf();
    }

    public void Enable(UnityComponent.Unit mainTarget)
    {
        this.mainTarget = mainTarget;
        this.enabled = true;
        Invoke(nameof(FindEnemy), 1);
    }

    private void Update()
    {
        if (currentTarget == null)
        {
            if (ai.Path.corners.Length == 0)
            {
                ai.CalculateRandomPath();
            }
        }

        if (currentTarget != null)
        {
            lookAt.LookTarget(currentTarget.transform.position);
        }
        else
        {
            lookAt.LookTarget(transform.right);
        }
    }

    private void FindEnemy()
    {
        if (mainTarget == null)
        {
            Invoke(nameof(FindEnemy), 1);
            return;
        }

        Vector2 direction = mainTarget.transform.position - transform.position;

        if (direction.magnitude > ai.ViewDistance)
        {
            Invoke(nameof(FindEnemy), 1);
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, layerMask);

        if (hit.collider == null)
        {
            Debug.DrawLine(transform.position, mainTarget.transform.position, Color.green, 1);
            currentTarget = mainTarget;
            ai.Path.ClearCorners();

            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                ai.Shoot(currentTarget.transform.position);
                Invoke(nameof(FindEnemy), 0.1f);
            }
            else
            {
                ai.CalculateRandomPath();
                Invoke(nameof(FindEnemy), 1);
            }
        }
        else
        {
            //Debug.Log("Hit: " + hit.collider.name);
            Debug.DrawLine(transform.position, hit.point, Color.red, 1);
            //Не видим врага
            currentTarget = null;
            Invoke(nameof(FindEnemy), 1);
        }
    }

    

    public void DisableSelf()
    {
        enabled = false;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

}
