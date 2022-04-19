using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{ 
    [CreateAssetMenu]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private int maxAmount;

        public string Name { get => name; private set => name = value; }
        public int MaxAmount { get => maxAmount; private set => maxAmount = value; }

        public ItemData() { }

        public ItemData(string name, int maxAmount) 
        {
            this.name = name;
            this.maxAmount = maxAmount;
        }
    }
}
