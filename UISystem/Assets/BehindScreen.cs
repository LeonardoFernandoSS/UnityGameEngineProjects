using System.Collections;

namespace ScreenSystem
{
    public class BehindScreen : ScreenState
    {
        public BehindScreen(ScreenUI machine) : base(machine) { }

        public override IEnumerator Start()
        {
            machine.CanvasGroup.interactable = false;
            machine.CanvasGroup.blocksRaycasts = false;

            machine.onLockedScreen?.Invoke();

            yield break;
        }

        public override IEnumerator UnlockElements()
        {
            machine.isLocked = false;

            machine.State = new InFrontScreen(machine);

            return base.UnlockElements();
        }

        public override IEnumerator HideElements()
        {
            machine.isLocked = false;

            machine.State = new InactiveScreen(machine);

            return base.HideElements();
        }
    }
}