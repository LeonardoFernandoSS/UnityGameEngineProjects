using UnityEngine;
using UnityEngine.UI;
using InteractionSystem;

public class IntroductionUI : MonoBehaviour
{
    [SerializeField] private Text txtInformation;

    private void Start()
    {
        InteractManager.onFocusedInteraction += LinkIntroduction;
        InteractManager.onUnfocusedInteraction += UnlinkIntroduction;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (InteractManager.instance.State is InitInteractor)
            {
                InteractManager.instance.OnStartInteraction();

                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InteractManager.instance.State is InitInteractor)
            {
                InteractManager.instance.OnCancelInteraction();

                return;
            }
        }
    }

    private void LinkIntroduction(IInteractable interactable) => interactable.Introduction.onChangedInformation += InformationUpdateUI;

    private void UnlinkIntroduction(IInteractable interactable) => interactable.Introduction.onChangedInformation -= InformationUpdateUI;

    private void InformationUpdateUI(string information) => txtInformation.text = information;
}
