using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data
{
    public interface IItemData
    {
        string Name { get; }

        int TransferAmount { get; }

        int MaxAmount { get; }
    }
}
