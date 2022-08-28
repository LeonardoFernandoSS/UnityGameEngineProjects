using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IntroductionSystem;
using IntroductionSystem.States;

public class TesterController : MonoBehaviour
{
    public PickUp pickUp;
    public IntroductionController introductionController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (introductionController.OnSubmitIntroduction()) return;

            if (pickUp.InitIntroduction()) return;
        }
    }

    public void DebugKnowTitle(IIntroductable introductable)
    {
        Debug.Log($"Iniciando introdução com {introductable.IntroductionData.title}.");
    }

    public void DebugDontKnowTitle(IIntroductable introductable)
    {
        string title = introductable.IntroductionData.title;

        if (introductable.IntroductionData.hiddenTitle) title = "???";

        Debug.Log($"Iniciando introdução com {title}.");
    }

    public void DebugRow()
    {
        Debug.Log(ControllerState.Row);
    }

    public void DebugFinish(IIntroductable introductable)
    {
        Debug.Log($"Finalizando introdução {introductable.IntroductionData.title}.");
    }
}
