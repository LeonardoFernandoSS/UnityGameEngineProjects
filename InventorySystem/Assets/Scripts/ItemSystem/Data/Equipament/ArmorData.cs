using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Equipament
{
    [CreateAssetMenu(menuName = "Item/Equipment/ArmorData")]
    public class ArmorData : EquipamentData, IEquipmentData
    {
        public float Attack { get => base.attack; }

        public float Defense { get => base.defense; }

        public float Speed { get => base.speed; }

        public string SlotEquipament { get => base.slotEquipament; }

        public void EquipEquipemt()
        {

        }
    }
}


