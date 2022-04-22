using System.Collections;

namespace ScreenSystem
{
    public class InactiveScreen : ScreenState
    {
        public InactiveScreen(ScreenUI machine) : base(machine) { }

        public override IEnumerator Start()
        {
            machine.CanvasGroup.interactable = false;
            machine.CanvasGroup.blocksRaycasts = false;

            machine.onInactivatedScreen?.Invoke();

            yield break;
        }

        public override IEnumerator ShowElements()
        {
            machine.State = new ActiveScreen(machine);

            return base.ShowElements();
        }
    }
}
