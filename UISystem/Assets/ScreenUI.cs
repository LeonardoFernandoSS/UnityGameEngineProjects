using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScreenSystem
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class ScreenUI :  MonoBehaviour
    {
        #region StateMachine

        public Action<ScreenState> onChangedState;

        private ScreenState state;

        public ScreenState State
        {
            get => state;
            set
            {
                state = value;

                onChangedState?.Invoke(state);

                StartCoroutine(state.Start());
            }
        }

        protected void Awake() => State = new InactiveScreen(this);

        #endregion

        [Space(10)]
        [SerializeField] public UnityEvent onInactivatedScreen;
        [SerializeField] public UnityEvent onActivatedScreen;
        [SerializeField] public UnityEvent onLockedScreen;
        [SerializeField] public UnityEvent onUnlockedScreen;

        [HideInInspector] public CanvasGroup CanvasGroup { get => GetComponent<CanvasGroup>(); }
        [HideInInspector] public bool isLocked { get; set; }

        public void ShowElements() => StartCoroutine(State.ShowElements());

        public void HideElements() => StartCoroutine(State.HideElements());

        public void LockElements() => StartCoroutine(State.LockElements());

        public void UnlockElements() => StartCoroutine(State.UnlockElements());
    }
}
