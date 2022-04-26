using System;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractManager : MonoBehaviour
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

        public Action<IInteractable> onFocusedInteraction;
        public Action<IInteractable> onStartedInteraction;
        public Action<IInteractable> onConfirmedInteraction;
        public Action<IInteractable> onCanceledInteraction;

        public IInteractable focus { get; private set; }

        [SerializeField] private float maxDistance = 5f;
        [SerializeField] private string interactiveTag = "Interactive";

        protected void Awake() => State = new IdleInteractor(this);

        public void ResetFocus() => focus = null;

        public void FindFocus()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.forward, out hit, maxDistance))
            {
                if (hit.collider.CompareTag(interactiveTag))
                {
                    focus = hit.collider.GetComponent<IInteractable>();
                }
            }
        }

        public void OnFocusInteraction() => StartCoroutine(State.FocusInteraction());

        public void OnStartInteraction() => StartCoroutine(State.StartInteraction());

        public void OnConfirmInteraction() => StartCoroutine(State.ConfirmInteraction());

        public void OnCancelInteraction() => StartCoroutine(State.CancelInteraction());
    }
}