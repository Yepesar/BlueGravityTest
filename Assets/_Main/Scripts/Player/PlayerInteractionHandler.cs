using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionHandler : MonoBehaviour
{
    public InputActionAsset actions;

    private IInteractable lastInteraction;

    InputAction interactionAction;

    // Start is called before the first frame update
    void Start()
    {
        interactionAction = actions.FindActionMap("Player").FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if (lastInteraction != null && interactionAction.triggered)
        {
            Debug.Log("Interacting!");
            lastInteraction = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            lastInteraction = interactable;
        }
    }
}
