using System.Collections;

namespace InteractionSystem
{
    public abstract class InteractorState
    {
        protected Interactor machine;

        public InteractorState(Interactor machine) => this.machine = machine;

        public abstract IEnumerator Start();

        public virtual IEnumerator FocusInteraction() { yield break; }

        public virtual IEnumerator StartInteraction() { yield break; }

        public virtual IEnumerator ConfirmInteraction() { yield break; }

        public virtual IEnumerator CancelInteraction() { yield break; }
    }
}
