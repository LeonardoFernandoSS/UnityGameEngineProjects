using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data
{
    public abstract class ItemData : ScriptableObject
    {
        [Header("General")]

        [SerializeField] protected new string name;
        [SerializeField] protected int transferAmount;
        [SerializeField] protected int maxAmount;

        //public ItemData() { }

        /*public ItemData(string name, int maxAmount) 
        {
            this.name = name;
            this.maxAmount = maxAmount;
        }*/

        //public virtual string Name { get => name; protected set => name = value; }

        //public virtual int TransferAmount { get => transferAmount; protected set => transferAmount = value; }

        //public virtual int MaxAmount { get => maxAmount; protected set => maxAmount = value; }
    }
}
