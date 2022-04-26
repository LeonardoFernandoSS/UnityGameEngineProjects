using System.Collections;

namespace InteractionSystem
{
    public abstract class InteractorState
    {
        protected InteractManager machine;

        public InteractorState(InteractManager machine) => this.machine = machine;

        public abstract IEnumerator Start();

        public virtual IEnumerator FocusInteraction() { yield break; }

        public virtual IEnumerator StartInteraction() { yield break; }

        public virtual IEnumerator ConfirmInteraction() { yield break; }

        public virtual IEnumerator CancelInteraction() { yield break; }
    }
}
