using DialogueEditor;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMerchant : MonoBehaviour
{
    private Vector2Int mapsize;
    private Vector2 moveTargetPoint;
    private Vector2 livePoint;
    private NavMeshPath path;
    private UnitMovePath unitMovePath;
    private InteractionObject interactionObject;

    [SerializeField] private NPCConversation conversation;

    private void Start()
    {
        interactionObject = Instantiate(StaticData.Instance.interactionObjectPrefab, transform);
        interactionObject.EventToInteract += InteractionObject_EventToInteract;
        Initialise(StaticData.Instance.gridData.GridSize);
    }

    public void Initialise(Vector2Int mapsize)
    {
        this.mapsize = mapsize;
        livePoint = transform.position;
        path = new NavMeshPath();
        unitMovePath = gameObject.AddComponent<UnitMovePath>();
        unitMovePath.Initialise(path);

        Invoke(nameof(CalculateRandomPath), 1);
    }

    private void CalculateRandomPath()
    {
        moveTargetPoint = RandomNavmeshLocation(livePoint, 1);
        NavMesh.CalculatePath(transform.position, moveTargetPoint, NavMesh.AllAreas, path);
        Invoke(nameof(CalculateRandomPath), Random.Range(1,10));
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

    private Vector3 RandomNavmeshLocation(Vector3 origin, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += origin;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas);
        return hit.position;
    }

    private void InteractionObject_EventToInteract(EcsEntity other)
    {
        ConversationManager.Instance.StartConversation(conversation);
        // ref var component = ref entity.Get<EcsComponent.PickUpSceneItemEvent>();
        // component.otherEntity = other;

        //component.worldPosition = transform.position;
        //ref var conteiners = ref entity.Get<EcsComponent.Bag>().conteiners;
        //component.conteiners = conteiners;
    }

    public void ShowInventary()
    {

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

    private void OnDestroy()
    {
        if (interactionObject != null)
        {
            interactionObject.EventToInteract -= InteractionObject_EventToInteract;
        }
    }

}
