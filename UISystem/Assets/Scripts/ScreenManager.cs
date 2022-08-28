using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ScreenSystem
{
    public static class ScreenManager
    {
        public static Action onDontHaveScreens;
        
        private static Stack<ScreenUI> screens = new Stack<ScreenUI>();

        private static Stack<GameObject> uiElements = new Stack<GameObject>();

        public static void OpenScreen(ScreenUI screen)
        {
            if (screen is null) return;

            LockScreen();           

            screen.ShowElements();

            screens.Push(screen);

            GameObject uiElement = EventSystem.current.currentSelectedGameObject;

            if (uiElement) uiElements.Push(uiElement);

            if (screen.DefaultUIElement) SelectElement(screen.DefaultUIElement);
        }

        public static void CloseScreen()
        {
            if (screens.Count == 0) return;

            ScreenUI screen = screens.Pop();

            screen.HideElements();

            if (uiElements.Count > 0) SelectElement(uiElements.Pop());
    
            UnlockScreen();
        }

        private static void LockScreen()
        {
            if (screens.Count == 0) return;

            ScreenUI old = screens.Peek();

            if (!(old is null)) old.LockElements();
        }

        private static void UnlockScreen()
        {
            if (screens.Count == 0)
            {
                onDontHaveScreens?.Invoke();

                return;
            }

            ScreenUI old = screens.Peek();

            if (!(old is null)) old.UnlockElements();
        }

        private static void SelectElement(GameObject uiElements) => EventSystem.current.SetSelectedGameObject(uiElements);
    }
}