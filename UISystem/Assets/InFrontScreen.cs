using System.Collections;

namespace ScreenSystem
{
    public class InFrontScreen : ScreenState
    {
        public InFrontScreen(ScreenUI machine) : base(machine) { }

        public override IEnumerator Start()
        {
            if (!machine.isLocked) yield break;

            machine.CanvasGroup.interactable = true;
            machine.CanvasGroup.blocksRaycasts = true;

            machine.onUnlockedScreen?.Invoke();

            yield break;
        }

        public override IEnumerator HideElements()
        {
            machine.State = new InactiveScreen(machine);

            return base.HideElements();
        }

        public override IEnumerator LockElements()
        {
            machine.isLocked = true;

            machine.State = new BehindScreen(machine);

            return base.LockElements();
        }
    }
}
