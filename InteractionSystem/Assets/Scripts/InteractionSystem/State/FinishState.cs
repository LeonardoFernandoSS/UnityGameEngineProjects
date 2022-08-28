using System;
using System.Collections;

namespace InteractionSystem.State
{
    public class FinishState : ControllerState
    {
        public override IEnumerator Start() 
        {
            controller.onFinishInteraction?.Invoke();

            controller.State = new IdleState();

            yield break; 
        }
    }
}
