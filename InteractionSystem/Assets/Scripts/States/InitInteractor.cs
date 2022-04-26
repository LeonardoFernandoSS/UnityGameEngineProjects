using System.Collections;

namespace InteractionSystem
{
    public class InitInteractor : InteractorState
    {
        public InitInteractor(InteractManager machine) : base(machine) { }

        public override IEnumerator Start()
        {
            machine.focus.Introduction.InitInformations();

            machine.OnStartInteraction();

            yield break;
        }

        public override IEnumerator StartInteraction()
        {
            if (machine.focus.Introduction.NextInformation()) yield break;

            machine.onStartedInteraction?.Invoke(machine.focus);

            machine.State = new BusyInteractor(machine);            

            yield break;
        }

        public override IEnumerator CancelInteraction()
        {
            machine.onCanceledInteraction?.Invoke(machine.focus);

            machine.State = new DelayInteractor(machine);

            yield break;
        }
    }
}
