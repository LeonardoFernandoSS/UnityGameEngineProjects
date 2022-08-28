using System.Collections;

namespace InteractionSystem.State
{
    public class InProcessState : ControllerState
    {
        public override IEnumerator Start() 
        {
            controller.State = new WaitState();

            yield break; 
        }
    }
}
