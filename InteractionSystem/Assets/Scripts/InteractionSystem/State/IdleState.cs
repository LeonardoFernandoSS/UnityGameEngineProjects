using System;
using System.Collections;

namespace InteractionSystem.State
{
    public class IdleState : ControllerState
    {
        public override IEnumerator Start()
        {
            interactable = null;

            yield break;
        }

        public override IEnumerator Init(IInteractable interactable)
        {
            if (ControllerState.interactable is not null)
            {
                controller.onFailInteraction?.Invoke();

                yield break;
            }

            ControllerState.interactable = interactable;

            controller.onInitInteraction?.Invoke(interactable);

            controller.State = new InProcessState();            

            yield break;
        }
    }
}
