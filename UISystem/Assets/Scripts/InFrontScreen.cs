using System.Collections;
using UnityEngine;

namespace ScreenSystem
{
    public class InFrontScreen : ScreenState
    {
        public InFrontScreen(ScreenUI machine) : base(machine) { }

        public override IEnumerator Start()
        {
            machine.onUnlockedScreen?.Invoke();

            yield return new WaitForSeconds(machine.UnlockTime);

            machine.State = new IdleScreen(machine);

            yield break;
        }
    }
}
