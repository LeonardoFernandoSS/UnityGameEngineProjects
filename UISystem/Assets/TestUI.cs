using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScreenSystem;
using ScreenSystem.Management;

[RequireComponent(typeof(CanvasGroup))]
public class TestUI : ScreenSystem.ScreenUI
{
    [Space(10)]
    [SerializeField] private ScreenSystem.ScreenUI nextScreen;

    public void OnNextScreen()
    {
        if (nextScreen)
        {
            ScreenManager.instance.OpenScreen(nextScreen);
        }        
    }
}
