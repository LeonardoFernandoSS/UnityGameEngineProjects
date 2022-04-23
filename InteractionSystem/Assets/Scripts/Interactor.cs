using System;
using UnityEngine;

namespace InteractionSystem
{
    public class Interactor : MonoBehaviour
    {
        #region StateMachine

        public Action<InteractorState> onChangedState;

        private InteractorState state;

        public InteractorState State
        {
            get => state;
            set
            {
                state = value;

                StartCoroutine(state.Start());

                onChangedState?.Invoke(state);
            }
        }

        #endregion

        public Action<InteractiveObject> onFocusedInteraction;
        public Action<InteractiveObject> onStartedInteraction;
        public Action<InteractiveObject> onConfirmedInteraction;
        public Action<InteractiveObject> onCanceledInteraction;

        public InteractiveObject focus { get; private set; }

        [SerializeField] private float maxDistance = 5f;
        [SerializeField] private string interactiveTag = "Interactive";

        protected void Awake() => State = new IdleInteractor(this);

        public void ResetInteractiveObject() => focus = null;

        public void FindInteractiveObject()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.forward, out hit, maxDistance))
            {
                if (hit.collider.CompareTag(interactiveTag))
                {
                    focus = hit.collider.GetComponent<InteractiveObject>();
                }
            }
        }

        public void OnFocusInteraction() => StartCoroutine(State.FocusInteraction());

        public void OnStartInteraction() => StartCoroutine(State.StartInteraction());

        public void OnConfirmInteraction() => StartCoroutine(State.ConfirmInteraction());

        public void OnCancelInteraction() => StartCoroutine(State.CancelInteraction());
    }
}