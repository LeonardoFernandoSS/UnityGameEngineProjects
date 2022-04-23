using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class InteractiveObject : MonoBehaviour
    {
        public Action<string> onChangedDialog;

        [SerializeField] private List<string> dialogs;

        public Queue<string> currentDialogs { get; private set; }

        public void InitDialogs()
        {
            currentDialogs = new Queue<string>(dialogs);

            NextDialog();
        }

        public void NextDialog() => onChangedDialog?.Invoke(currentDialogs.Dequeue());

        public abstract void Interact();
    }
}