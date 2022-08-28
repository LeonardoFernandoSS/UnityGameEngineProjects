using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Equipament
{
    public interface IEquipmentData
    {
        string SlotEquipament { get; }

        float Attack { get; }

        float Defense { get; }

        float Speed { get; }

        void EquipEquipemt();
    }
}