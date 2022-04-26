using UnityEngine;
using InteractionSystem;

[RequireComponent(typeof(InteractManager))]
public class PlayerTest : MonoBehaviour
{
    private InteractManager InteractManager { get => GetComponent<InteractManager>(); }

    private void Start()
    {
        InteractManager.onFocusedInteraction += StartInteraction;
        InteractManager.onUnfocusedInteraction += StopInteraction;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (InteractManager.State is IdleInteractor)
            {
                InteractManager.OnFocusInteraction();

                return;
            }
        }
    }

    private void StartInteraction(IInteractable interactiveObject) => Debug.Log("Start interaction!");

    private void StopInteraction(IInteractable interactiveObject) => Debug.Log("Stop interaction!");
}