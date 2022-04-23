using System.Collections;

namespace ScreenSystem
{
    public abstract class ScreenState
    {
        protected ScreenUI machine;

        public ScreenState(ScreenUI machine) => this.machine = machine;

        public abstract IEnumerator Start();

        public virtual IEnumerator ShowElements() { yield break; }

        public virtual IEnumerator HideElements() { yield break; }

        public virtual IEnumerator LockElements() { yield break; }

        public virtual IEnumerator UnlockElements() { yield break; }
    }
}
