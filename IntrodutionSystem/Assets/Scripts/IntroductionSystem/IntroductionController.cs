using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using IntroductionSystem.States;

namespace IntroductionSystem
{
    public class IntroductionController : MonoBehaviour
    {
        #region Singleton

        private static IntroductionController instance;

        public static IntroductionController Instance { get => instance; }

        private void Awake()
        {
            instance = this;
        }

        #endregion

        #region StateMachine

        private ControllerState state;

        public ControllerState State
        {

            get => state;
            set
            {
                state = value;

                state.Controller = this;

                StartCoroutine(state.Start());
            }
        }

        #endregion

        [Header("Interaction Events")]
        [Space(10)]
        [SerializeField] public UnityEvent<IIntroductable> onInitIntroduction;
        [SerializeField] public UnityEvent<IIntroductable> onKnowIntroduction;
        [SerializeField] public UnityEvent onChangeRow;
        [SerializeField] public UnityEvent<IIntroductable> onFinishIntroduction;

        private void Start() => State = new IdleState();

        private List<IIntroductable> knowIntroductions = new List<IIntroductable>();

        public bool KnowIntroduction(IIntroductable introduction) => knowIntroductions.Exists(x => x == introduction);

        public void AddIntroduction(IIntroductable introduction) => knowIntroductions.Add(introduction);

        public bool OnSubmitIntroduction()
        {
            if (State is not WaitState) return false;

            StartCoroutine(State.Next());

            return true;
        }

        public bool OnInitIntroduction(IIntroductable introduction)
        {
            if (State is not IdleState) return false;

            StartCoroutine(State.Init(introduction));

            return true;
        }
    }
}
