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
    private NPCConversation conversation;
    private EcsEntity otherEntity;

    public void Initialise(Vector2Int mapsize)
    {
        this.mapsize = mapsize;
        livePoint = transform.position;
        path = new NavMeshPath();
        unitMovePath = gameObject.AddComponent<UnitMovePath>();
        unitMovePath.Initialise(path);

        interactionObject = Instantiate(StaticData.Instance.interactionObjectPrefab, transform);
        interactionObject.EventToInteract += InteractionObject_EventToInteract;

        conversation = Instantiate(StaticData.Instance.merchantConversation, transform);
        NodeEventHolder node = this.conversation.GetNodeData(1);
        node.Event.AddListener(ShowTradeInventary);


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
        otherEntity = other;

        if (otherEntity.IsNull())
        {
            Debug.LogError("Other Entity is null");
            return;
        }

        if (ConversationManager.Instance == null)
        {
            Debug.Log("ConversationManager is null");
            return;
        }

        ConversationManager.Instance.StartConversation(conversation);
    }

    public void ShowTradeInventary()
    {
        if (otherEntity.IsNull())
        {
            Debug.LogError("Other Entity is null");
            return;
        }

        EcsEntity entity = GetComponent<UnityComponent.Unit>().entity;
        ref var component = ref entity.Get<EcsComponent.ShowTradeMenuEvent>();
        component.otherEntity = otherEntity;
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
