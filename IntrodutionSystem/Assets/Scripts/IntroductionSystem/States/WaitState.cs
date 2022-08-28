using System.Collections;

namespace IntroductionSystem.States
{
    public class WaitState : ControllerState
    {
        public override IEnumerator Start() { yield break; }

        public override IEnumerator Next()
        {
            if (rows.Count > 0) controller.State = new InProcessState();

            else controller.State = new FinishState();

            yield break;
        }
    }
}
