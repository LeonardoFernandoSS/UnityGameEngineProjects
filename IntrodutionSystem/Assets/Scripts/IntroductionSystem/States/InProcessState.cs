using System;
using System.Collections;

namespace IntroductionSystem.States
{
    public class InProcessState : ControllerState
    {
        public override IEnumerator Start()
        {
            Row = rows.Dequeue();

            controller.onChangeRow?.Invoke();

            controller.State = new WaitState();

            yield break;
        }
    }
}
