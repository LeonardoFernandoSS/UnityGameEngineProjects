using System.Collections;
using UnityEngine;

namespace InteractionSystem
{
    public class DelayInteractor : InteractorState
    {
        public DelayInteractor(InteractManager machine) : base(machine) { }

        public override IEnumerator Start()
        {
            InteractManager.onUnfocusedInteraction?.Invoke(machine.focus);

            machine.ResetFocus();            

            yield return new WaitForSeconds(1f);

            machine.State = new IdleInteractor(machine);

            yield break;
        }
    }
}
