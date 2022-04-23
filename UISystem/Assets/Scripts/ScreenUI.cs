using System;
using UnityEngine;
using UnityEngine.UI;
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

        #endregion

        [SerializeField] private bool isDefaultScreen;

        [Space(10)]
        [SerializeField] private float activeTime;
        [SerializeField] private float unlockTime;

        [Space(10)]
        [SerializeField] private GameObject defaultUIElement;

        [Space(10)]
        [SerializeField] public UnityEvent onInactivatedScreen;
        [SerializeField] public UnityEvent onActivatedScreen;
        [SerializeField] public UnityEvent onLockedScreen;
        [SerializeField] public UnityEvent onUnlockedScreen;

        [HideInInspector] public CanvasGroup CanvasGroup { get => GetComponent<CanvasGroup>(); }
        [HideInInspector] public bool isLocked { get; set; }
        
        [HideInInspector] public float ActiveTime { get => activeTime; }
        [HideInInspector] public float UnlockTime { get => unlockTime; }

        [HideInInspector] public GameObject DefaultUIElement { get => defaultUIElement; }

        protected void Awake() 
        {
            State = new InactiveScreen(this);

            if (isDefaultScreen) ScreenManager.OpenScreen(this);
        }

        public void ShowElements() => StartCoroutine(State.ShowElements());

        public void HideElements() => StartCoroutine(State.HideElements());

        public void LockElements() => StartCoroutine(State.LockElements());

        public void UnlockElements() => StartCoroutine(State.UnlockElements());

        public void OnClose() => ScreenManager.CloseScreen();

        public void OnNext(ScreenUI screen) => ScreenManager.OpenScreen(screen);
    }
}
