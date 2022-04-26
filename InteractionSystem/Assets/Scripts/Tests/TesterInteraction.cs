using UnityEngine;
using InteractionSystem;

public class TesterInteraction : MonoBehaviour
{
    [SerializeField] private Interactor interactor;

    private void Start()
    {
        interactor.onFocusedInteraction += TestFocus;
        interactor.onStartedInteraction += TestStart;
        interactor.onCanceledInteraction += TestCancelOrConfirm;
        interactor.onConfirmedInteraction += TestCancelOrConfirm;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !(interactor.State is IdleInteractor)) interactor.OnCancelInteraction();

        if (Input.GetKeyDown(KeyCode.Space) && interactor.State is BusyInteractor) interactor.OnConfirmInteraction();

        if (Input.GetKeyDown(KeyCode.Space) && interactor.State is InitInteractor) interactor.OnStartInteraction();

        if (Input.GetKeyDown(KeyCode.Space) && interactor.State is IdleInteractor) interactor.OnFocusInteraction();
    }

    private void TestFocus(IInteractable interactiveObject)
    {
        interactiveObject.Introduction.onChangedInformation += TestDialog;
    }

    private void TestStart(IInteractable interactiveObject)
    {
        Debug.Log("Do you want to interact object?");
    }

    private void TestCancelOrConfirm(IInteractable interactiveObject)
    {
        interactiveObject.Introduction.onChangedInformation -= TestDialog;
    }

    private void TestDialog(string dialog)
    {
        Debug.Log("Information: " + dialog);
    }
}