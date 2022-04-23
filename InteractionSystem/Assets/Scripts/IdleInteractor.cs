using System.Collections;

namespace InteractionSystem
{
    public class IdleInteractor : InteractorState
    {
        public IdleInteractor(Interactor machine) : base(machine) { }

        public override IEnumerator Start()
        {
            yield break;
        }

        public override IEnumerator FocusInteraction()
        {
            machine.FindInteractiveObject();

            if (machine.focus is null) yield break;

            machine.onFocusedInteraction?.Invoke(machine.focus);

            machine.State = new InitInteractor(machine);            

            yield break;
        }
    }
}
