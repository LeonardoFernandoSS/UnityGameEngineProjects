using UnityEngine;
using InteractionSystem;

public class InteractionUI : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (InteractManager.instance.State is BusyInteractor)
            {
                InteractManager.instance.OnConfirmInteraction();

                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InteractManager.instance.State is BusyInteractor)
            {
                InteractManager.instance.OnCancelInteraction();

                return;
            }
        }
    }
}