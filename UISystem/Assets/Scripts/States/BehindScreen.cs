using System.Collections;

namespace ScreenSystem.States
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
            machine.State = new InFrontScreen(machine);

            yield break;
        }

        public override IEnumerator HideElements()
        {
            machine.State = new InactiveScreen(machine);

            yield break;
        }
    }
}