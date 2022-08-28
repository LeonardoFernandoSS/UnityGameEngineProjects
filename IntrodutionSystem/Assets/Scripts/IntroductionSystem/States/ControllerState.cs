using System.Collections;
using System.Collections.Generic;

namespace IntroductionSystem.States
{
    public abstract class ControllerState
    {
        protected static IntroductionController controller;

        protected static IIntroductable introduction;

        protected static Queue<string> rows = new Queue<string>();

        public static string Row { get; protected set; }

        public IntroductionController Controller { private get => controller; set => controller = value; }

        public abstract IEnumerator Start();

        public virtual IEnumerator Init(IIntroductable introduction) { yield break; }

        public virtual IEnumerator Next() { yield break; }
    }
}
