using System.Collections;
using UnityEngine;

namespace ScreenSystem.States
{
    public class ActiveScreen : ScreenState
    {
        public ActiveScreen(ScreenUI machine) : base(machine) { }

        public override IEnumerator Start()
        {
            machine.onActivatedScreen?.Invoke();

            yield return new WaitForSeconds(machine.ActiveTime);

            machine.State = new IdleScreen(machine);

            yield break;
        }
    }
}
