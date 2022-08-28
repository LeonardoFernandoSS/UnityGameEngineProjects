using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Munition
{
    public abstract class MunitionData : ItemData, IItemData
    {
        public string Name { get => base.name; }

        public int TransferAmount { get => base.transferAmount; }

        public int MaxAmount { get => base.maxAmount; }
    }
}
