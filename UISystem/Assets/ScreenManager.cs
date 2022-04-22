using System;
using System.Collections;
using System.Collections.Generic;

namespace ScreenSystem
{
    public static class ScreenManager
    {
        //public static Action<ScreenUI> onOpenedScreen;
        //public static Action<ScreenUI> onClosedScreen;
        public static Action onDontHaveScreens;

        private static Stack<ScreenUI> screens = new Stack<ScreenUI>();

        public static void OpenScreen(ScreenUI screen)
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

            //onOpenedScreen?.Invoke(screen);
        }

        public static void CloseScreen()
        {
            if (screens.Count == 0) return;

            ScreenUI screen = screens.Pop();

            if (screen == null) return;

            screen.HideElements();

            //onClosedScreen?.Invoke(screen);

            if (screens.Count > 0)
            {
                ScreenUI old = screens.Peek();

                if (!old)
                {
                    old.UnlockElements();
                }
            }
            else
            {
                onDontHaveScreens?.Invoke();
            }
        }
    }
}