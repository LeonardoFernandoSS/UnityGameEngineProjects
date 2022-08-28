using System;
using System.Collections;

namespace IntroductionSystem.States
{
    public class FinishState : ControllerState
    {
        public override IEnumerator Start()
        {
            controller.AddIntroduction(introduction);

            controller.onFinishIntroduction?.Invoke(introduction);

            controller.State = new IdleState();

            yield break;
        }
    }
}
