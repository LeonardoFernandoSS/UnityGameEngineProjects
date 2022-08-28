using System;
using System.Collections;

namespace InteractionSystem.State
{
    public class WaitState : ControllerState
    {
        public override IEnumerator Start() { yield break; }

        public override IEnumerator Confirm()
        {
            controller.onConfirmInteraction?.Invoke();

            controller.State = new FinishState();

            yield break;
        }

        public override IEnumerator Cancell()
        {
            controller.onCancellInteraction?.Invoke();

            controller.State = new FinishState();

            yield break;
        }
    }
}
