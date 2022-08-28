using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Equipament
{
    public abstract class EquipamentData : ItemData, IItemData
    {
        [Header("Equipament")]

        [SerializeField] protected string slotEquipament;

        [SerializeField] protected float attack;

        [SerializeField] protected float defense;

        [SerializeField] protected float speed;

        public string Name { get => base.name; }

        public int TransferAmount { get => base.transferAmount; }

        public int MaxAmount { get => base.maxAmount; }
    }
}