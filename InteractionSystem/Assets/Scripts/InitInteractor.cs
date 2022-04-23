using System.Collections;

namespace InteractionSystem
{
    public class InitInteractor : InteractorState
    {
        public InitInteractor(Interactor machine) : base(machine) { }

        public override IEnumerator Start()
        {
            machine.focus.InitDialogs();

            yield break;
        }

        public override IEnumerator StartInteraction()
        {
            if (machine.focus.currentDialogs.Count > 0)
            {
                machine.focus.NextDialog();

                yield break;
            }

            machine.onStartedInteraction?.Invoke(machine.focus);

            machine.State = new BusyInteractor(machine);            

            yield break;
        }
    }
}
