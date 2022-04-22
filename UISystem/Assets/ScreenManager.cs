using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScreenSystem
{
    public static class ScreenManager
    {
        //public static Action<ScreenUI> onOpenedScreen;
        //public static Action<ScreenUI> onClosedScreen;
        public static Action onDontHaveScreens;
        
        private static Stack<ScreenUI> screens = new Stack<ScreenUI>();

        private static Stack<GameObject> uiElements = new Stack<GameObject>();

        public static void OpenScreen(ScreenUI screen)
        {
            if (screen is null) return;

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

            GameObject uiElement = EventSystem.current.currentSelectedGameObject;

            if (uiElement) uiElements.Push(uiElement);

            if (screen.DefaultUIElement) EventSystem.current.SetSelectedGameObject(screen.DefaultUIElement);

            //onOpenedScreen?.Invoke(screen);

            Debug.ClearDeveloperConsole();
            Debug.Log(screens.Count);
        }

        public static void CloseScreen()
        {
            if (screens.Count == 0) return;

            ScreenUI screen = screens.Pop();

            screen.HideElements();

            if (uiElements.Count > 0) EventSystem.current.SetSelectedGameObject(uiElements.Pop());

            //onClosedScreen?.Invoke(screen);

            if (screens.Count > 0)
            {
                ScreenUI old = screens.Peek();

                if (!old) old.UnlockElements();
            }
            else onDontHaveScreens?.Invoke();

            Debug.ClearDeveloperConsole();
            Debug.Log(screens.Count);
        }
    }
}