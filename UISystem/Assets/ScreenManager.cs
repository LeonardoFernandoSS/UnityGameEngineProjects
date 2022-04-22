using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScreenSystem.Management
{
    public class ScreenManager : MonoBehaviour
    {
        #region Singleton

        public static ScreenManager instance;

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        #endregion

        public static Action<ScreenUI> onOpenedScreen;
        public static Action<ScreenUI> onClosedScreen;

        private Stack<ScreenUI> screens = new Stack<ScreenUI>();

        [SerializeField] private ScreenUI defaultScreen;

        private void Start() => instance.OpenScreen(defaultScreen);

        public void OpenScreen(ScreenUI screen)
        {
            if (screen == null) return;

            if (screens.Count > 0)
            {
                ScreenUI old = screens.Peek();

                if (!old)
                {
                    old.LockElements();
                }
            }            

            screen.ShowElements();

            screens.Push(screen);

            onOpenedScreen?.Invoke(screen);
        }

        public void OnCloseScreen()
        {
            if (screens.Count == 0) return;

            ScreenUI screen = screens.Pop();

            if (screen == null) return;

            screen.HideElements();

            onClosedScreen?.Invoke(screen);

            if (screens.Count > 0)
            {
                ScreenUI old = screens.Peek();

                if (!old)
                {
                    old.UnlockElements();
                }
            }            
        }
    }
}
