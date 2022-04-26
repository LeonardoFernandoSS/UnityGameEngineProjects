using System.Collections;

namespace InteractionSystem
{
    public class IdleInteractor : InteractorState
    {
        public IdleInteractor(InteractManager machine) : base(machine) { }

        public override IEnumerator Start()
        {
            yield break;
        }

        public override IEnumerator FocusInteraction()
        {
            machine.FindFocus();

            if (machine.focus is null) yield break;

            InteractManager.onFocusedInteraction?.Invoke(machine.focus);

            machine.State = new InitInteractor(machine);            

            yield break;
        }
    }
}
