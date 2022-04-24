using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public abstract class InteractiveObject : MonoBehaviour
    {
        public Action<string> onChangedInformation;

        private Queue<string> currentInformations;

        [SerializeField] private List<string> informations;        

        public bool InitInformations()
        {
            currentInformations = new Queue<string>(informations);

            return NextInformation();
        }

        public bool NextInformation()
        {
            if (currentInformations.Count == 0) return false;

            onChangedInformation?.Invoke(currentInformations.Dequeue());

            return true;
        }

        public abstract void Interact();
    }
}