using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Restore
{
    public abstract class RestoreData : ItemData, IItemData
    {
        public string Name { get => base.name; }

        public int TransferAmount { get => base.transferAmount; }

        public int MaxAmount { get => base.maxAmount; }
    }
}
