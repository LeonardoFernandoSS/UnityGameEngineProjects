using System.Collections;
using UnityEngine;

namespace InteractionSystem
{
    public class DelayInteractor : InteractorState
    {
        public DelayInteractor(Interactor machine) : base(machine) { }

        public override IEnumerator Start()
        {
            machine.ResetFocus();

            yield return new WaitForSeconds(1f);

            machine.State = new IdleInteractor(machine);

            yield break;
        }
    }
}
