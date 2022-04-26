using System;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    [Serializable]
    public class InteractIntroduction
    {
        public Action<string> onChangedInformation;

        private Queue<string> currentInformations;

        [SerializeField] private List<string> informations;

        public void InitInformations() => currentInformations = new Queue<string>(informations);

        public bool NextInformation()
        {
            if (currentInformations.Count == 0) return false;

            onChangedInformation?.Invoke(currentInformations.Dequeue());

            return true;
        }
    }
}