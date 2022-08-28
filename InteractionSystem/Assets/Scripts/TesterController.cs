using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionSystem;
using InteractionSystem.State;

public class TesterController : MonoBehaviour
{
    public PickUp pickUp;
    public InteractionController interactionController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (interactionController.OnConfirmInteraction()) return;

            pickUp.Interact();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (interactionController.OnCancellInteraction()) return;
        }
    }

    public void DebugFail()
    {
        Debug.Log($"Falhou interação.");
    }

    public void DebugInit(IInteractable interactable)
    {
        Debug.Log($"Iniciando interação.");
    }

    public void DebugConfirm()
    {
        Debug.Log($"Confirmou interação.");
    }

    public void DebugCancell()
    {
        Debug.Log($"Cancelou interação.");
    }

    public void DebugFinish()
    {
        Debug.Log($"Finalizando interação");
    }
}
