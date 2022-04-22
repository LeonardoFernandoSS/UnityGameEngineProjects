using System.Collections;

namespace ScreenSystem
{
    public class InactiveScreen : ScreenState
    {
        public InactiveScreen(ScreenUI machine) : base(machine) { }

        public override IEnumerator Start()
        {
            machine.onInactivatedScreen?.Invoke();

            machine.CanvasGroup.interactable = false;
            machine.CanvasGroup.blocksRaycasts = false;

            yield break;
        }

        public override IEnumerator ShowElements()
        {
            machine.State = new ActiveScreen(machine);

            yield break;
        }
    }
}
