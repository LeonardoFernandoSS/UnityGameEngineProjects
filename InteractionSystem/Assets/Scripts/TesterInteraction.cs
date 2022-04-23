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
        if (Input.GetKeyDown(KeyCode.Space) && interactor.State is BusyInteractor) interactor.OnConfirmInteraction();

        if (Input.GetKeyDown(KeyCode.Space) && interactor.State is InitInteractor) interactor.OnStartInteraction();

        if (Input.GetKeyDown(KeyCode.Space) && interactor.State is IdleInteractor) interactor.OnFocusInteraction();
    }

    public void TestFocus(InteractiveObject interactiveObject)
    {
        interactiveObject.onChangedDialog += TestDialog;
    }

    public void TestStart(InteractiveObject interactiveObject)
    {
        Debug.Log("Do you want to interact object: " + interactiveObject.name);
    }

    public void TestCancelOrConfirm(InteractiveObject interactiveObject)
    {
        interactiveObject.onChangedDialog -= TestDialog;
    }

    public void TestDialog(string dialog)
    {
        Debug.Log("Dialog: " + dialog);
    }
}