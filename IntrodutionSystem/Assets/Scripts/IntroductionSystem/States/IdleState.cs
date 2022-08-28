using System;
using System.Collections;
using UnityEngine;

namespace IntroductionSystem.States
{
    public class IdleState : ControllerState
    {
        public override IEnumerator Start()
        {
            introduction = null;

            yield break;
        }

        public override IEnumerator Init(IIntroductable introduction)
        {
            ControllerState.introduction = introduction;
            
            if (controller.KnowIntroduction(introduction))
            {
                controller.onKnowIntroduction?.Invoke(introduction);

                controller.State = new IdleState();

                yield break;
            }

            rows = introduction.IntroductionData.content.GetRows(rows);

            controller.onInitIntroduction?.Invoke(introduction);

            controller.State = new InProcessState();

            yield break;
        }
    }
}
