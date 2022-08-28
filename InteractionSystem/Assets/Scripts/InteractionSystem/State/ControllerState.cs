using System.Collections;

namespace InteractionSystem.State
{
    public abstract class ControllerState
    {
        protected static InteractionController controller;

        protected static IInteractable interactable;

        public InteractionController Controller { private get => controller; set => controller = value; }

        public abstract IEnumerator Start();

        public virtual IEnumerator Init(IInteractable interactable) { yield break; }

        public virtual IEnumerator Confirm() { yield break; }

        public virtual IEnumerator Cancell() { yield break; }

        public virtual IEnumerator Finish() { yield break; }
    }
}
