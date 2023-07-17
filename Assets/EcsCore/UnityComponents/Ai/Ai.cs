using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    private AiMerchant aiMerchant;
    private AiCombat aiCombat;
    private EcsEntity entitySelf;
    
    private UnitMovePath unitMovePath;

    private InteractionObject interactionObject;

    public NavMeshPath Path => path;
    private NavMeshPath path;

    public float ViewDistance => viewDistance;
    private const float viewDistance = 5;

    public void Initialise(EcsEntity entitySelf)
    {
        this.entitySelf = entitySelf;
       
        path = new NavMeshPath();

        unitMovePath = gameObject.AddComponent<UnitMovePath>();
        unitMovePath.Initialise(path);

        var hitHandler = transform.parent.GetComponentInChildren<UnityComponent.HitHandler>();
        hitHandler.EventOnHit += HitHandler_EventOnHit;

        interactionObject = Instantiate(StaticData.Instance.interactionObjectPrefab, transform);
        aiCombat = GetComponent<AiCombat>();
        aiCombat.Initialise(this);
        aiMerchant = GetComponent<AiMerchant>();
        aiMerchant.Initialise(interactionObject);
        aiMerchant.EnableSelf();
    }

    private void HitHandler_EventOnHit(EcsEntity origineEntity)
    {
        aiMerchant.DisableSelf();

        if (origineEntity.Has<EcsComponent.Unit>())
        {
            var ecscomponent = origineEntity.Get<EcsComponent.Unit>();
            aiCombat.Enable(ecscomponent.UnitGO);

            if (entitySelf.Has<EcsComponent.EquipWeapon>() == false)
            {
                entitySelf.Get<EcsComponent.EquippingWeaponIntent>();
            }
        }
    }

    public bool RandomPointOnNavMesh(Vector2 startPosition, float radius, out Vector2 resultPosition)
    {
        resultPosition = startPosition;
        Vector2 randomDirection = Random.insideUnitCircle * radius;
        randomDirection += startPosition;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            resultPosition = hit.position;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CalculateRandomPath()
    {
        Vector2 moveTargetPoint = transform.position;
        RandomPointOnNavMesh(transform.position, viewDistance, out moveTargetPoint);

        if (NavMesh.CalculatePath(transform.position, moveTargetPoint, NavMesh.AllAreas, path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CalculateRandomPath(Vector2 startPosition, float radius, out NavMeshPath path)
    {
        path = new NavMeshPath();
        Vector2 moveTargetPoint = startPosition;
        RandomPointOnNavMesh(startPosition, radius, out moveTargetPoint);

        if (NavMesh.CalculatePath(startPosition, moveTargetPoint, NavMesh.AllAreas, path))
        {
            return true;
        }
        else
        {
            return false;
        }    
    }

    public void Shoot(Vector3 targetPosition)
    {
        entitySelf.Get<EcsComponent.ShootEvent>().TargetPosition = (Vector2)targetPosition;
    }

    private void OnDrawGizmosSelected()
    {
        if (path != null)
        {
            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                Debug.DrawLine(path.corners[i], path.corners[i + 1]);
            }
        }
    }

}
