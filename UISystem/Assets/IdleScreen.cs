using System.Collections;

namespace ScreenSystem
{
    public class IdleScreen : ScreenState
    {
        public IdleScreen(ScreenUI machine) : base(machine) { }

        public override IEnumerator Start()
        {
            machine.CanvasGroup.interactable = true;
            machine.CanvasGroup.blocksRaycasts = true;

            yield break;
        }

        public override IEnumerator HideElements()
        {
            machine.State = new InactiveScreen(machine);

            yield break;
        }

        public override IEnumerator LockElements()
        {
            machine.State = new BehindScreen(machine);

            yield break;
        }
    }
}
