using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface ILookTarget
{
    event Action<Vector2> EventLookAt;
}

public class AiCombat : MonoBehaviour, ILookTarget
{
    [SerializeField] private int layerMask;

    public event Action<Vector2> EventLookAt;
    public event Action<Vector2> EventDesireToAttack;

    private Vector2Int mapsize;
    private Vector2 moveTargetPoint;
    private NavMeshPath path;
    private UnitMovePath unitMovePath;
    private UnityComponent.Unit mainTarget;
    private UnityComponent.Unit currentTarget;

    private const float viewDistance = 5;

    public void Initialise(Vector2Int mapsize, UnityComponent.Unit target)
    {
        layerMask = 1 << LayerMask.NameToLayer("Default");
        this.mapsize = mapsize;
        this.mainTarget = target;
        path = new NavMeshPath();
        unitMovePath = gameObject.AddComponent<UnitMovePath>();
        unitMovePath.Initialise(path);

        Invoke(nameof( FindEnemy), 1);

    }

    private bool RandomPoint(out Vector3 position)
    {
        position = new Vector2(UnityEngine.Random.Range(-mapsize.x / 2, mapsize.x / 2),
                               UnityEngine.Random.Range(-mapsize.y / 2, mapsize.y / 2));
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 10.0f, NavMesh.AllAreas))
        {
            position = hit.position;
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (currentTarget == null)
        {
            if(path.corners.Length == 0)
            {
                CalculateRandomPath();
            }
        }

        LookTarget();
    }

    private void FindEnemy()
    {
        if (mainTarget == null)
        {
            Invoke(nameof(FindEnemy), 1);
            return;
        }

        Vector2 direction = mainTarget.transform.position - transform.position;

        if (direction.magnitude > viewDistance)
        {
            Invoke(nameof(FindEnemy), 1);
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, direction.magnitude, layerMask);

        if (hit.collider == null)
        {
            Debug.DrawLine(transform.position, mainTarget.transform.position, Color.green, 1);
            currentTarget = mainTarget;
            path.ClearCorners();

            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                EventDesireToAttack?.Invoke(currentTarget.transform.position);
                Invoke(nameof(FindEnemy), 0.1f);
            }
            else
            {
                CalculateRandomPath();
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

    private void CalculateRandomPath()
    {
        if (RandomPoint(out Vector3 position))
        {
            moveTargetPoint = position;
        }

        if (NavMesh.CalculatePath(transform.position, moveTargetPoint, NavMesh.AllAreas, path))
        {
            //unitMovePath.SetPath(path);
        }
    }

    public void PathClear()
    {

    }

    private void OnDrawGizmosSelected()
    {
        if(path != null)
        {
            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                Debug.DrawLine(path.corners[i], path.corners[i + 1]);
            }
        }
    }

    private void LookTarget()
    {
        if (currentTarget != null)
        {
            EventLookAt?.Invoke(currentTarget.transform.position);
        }
        else
        {
            EventLookAt?.Invoke(transform.right);
        }
    }
}
