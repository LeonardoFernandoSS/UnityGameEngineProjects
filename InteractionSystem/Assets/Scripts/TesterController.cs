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
        Debug.Log($"Falhou intera��o.");
    }

    public void DebugInit(IInteractable interactable)
    {
        Debug.Log($"Iniciando intera��o.");
    }

    public void DebugConfirm()
    {
        Debug.Log($"Confirmou intera��o.");
    }

    public void DebugCancell()
    {
        Debug.Log($"Cancelou intera��o.");
    }

    public void DebugFinish()
    {
        Debug.Log($"Finalizando intera��o");
    }
}
