using System.Collections;

namespace InteractionSystem
{
    public class BusyInteractor : InteractorState
    {
        public BusyInteractor(InteractManager machine) : base(machine) { }

        public override IEnumerator Start() 
        { 
            yield break; 
        }

        public override IEnumerator ConfirmInteraction()
        {
            machine.focus.Interact();

            machine.onConfirmedInteraction?.Invoke(machine.focus);

            machine.State = new DelayInteractor(machine);            

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
