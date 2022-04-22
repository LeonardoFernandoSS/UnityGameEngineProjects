using System.Collections;

namespace ScreenSystem
{
    public class ActiveScreen : ScreenState
    {
        public ActiveScreen(ScreenUI machine) : base(machine) { }

        public override IEnumerator Start()
        {
            machine.CanvasGroup.interactable = true;
            machine.CanvasGroup.blocksRaycasts = true;

            machine.onActivatedScreen?.Invoke();

            machine.State = new InFrontScreen(machine);

            yield break;
        }
    }
}
