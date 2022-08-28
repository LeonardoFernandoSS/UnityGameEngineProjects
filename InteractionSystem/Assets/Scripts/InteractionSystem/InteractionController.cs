using System;
using UnityEngine;
using InteractionSystem.State;
using UnityEngine.Events;

namespace InteractionSystem
{
    public class InteractionController : MonoBehaviour
    {
        #region Singleton

        private static InteractionController instance;

        public static InteractionController Instance { get => instance; }

        protected void Awake() => instance = this;

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
        [SerializeField] public UnityEvent<IInteractable> onInitInteraction;
        [SerializeField] public UnityEvent onFailInteraction;
        [SerializeField] public UnityEvent onConfirmInteraction;
        [SerializeField] public UnityEvent onCancellInteraction;
        [SerializeField] public UnityEvent onFinishInteraction;

        protected void Start() => State = new IdleState();

        public bool OnInitInteraction(IInteractable interactable)
        {
            if (State is not IdleState) return false;

            StartCoroutine(State.Init(interactable));

            return true;
        }

        public bool OnConfirmInteraction()
        {
            if (State is not WaitState) return false;

            StartCoroutine(State.Confirm());

            return true;
        }

        public bool OnCancellInteraction()
        {
            if (State is not WaitState) return false;

            StartCoroutine(State.Cancell());

            return true;
        }
    }
}