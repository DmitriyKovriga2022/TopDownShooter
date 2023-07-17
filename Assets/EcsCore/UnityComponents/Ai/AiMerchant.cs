using DialogueEditor;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMerchant : MonoBehaviour
{
    private InteractionObject interactionObject;
    private NPCConversation conversation;
    private EcsEntity otherEntity;

    public void Initialise(InteractionObject interactionObject)
    {
        this.interactionObject = interactionObject;
        conversation = Instantiate(StaticData.Instance.merchantConversation, transform);
        NodeEventHolder node = this.conversation.GetNodeData(1);
        node.Event.AddListener(ShowTradeInventary);
        DisableSelf();
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

        EcsEntity selfEntity = transform.parent.GetComponent<UnityComponent.Unit>().selfEntity;
        ref var component = ref selfEntity.Get<EcsComponent.ShowTradeMenuEvent>();
        component.otherEntity = otherEntity;
    }

    private void OnDestroy()
    {
        if (interactionObject != null)
        {
            interactionObject.EventToInteract -= InteractionObject_EventToInteract;
        }
    }

    public void EnableSelf()
    {
        interactionObject.EventToInteract += InteractionObject_EventToInteract;
        enabled = false;
    }

    public void DisableSelf()
    {
        interactionObject.EventToInteract -= InteractionObject_EventToInteract;
        enabled = false;
    }

}
