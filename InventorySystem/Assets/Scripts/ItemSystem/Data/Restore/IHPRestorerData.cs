using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Restore
{
    public interface IHPRestorerData : IItemData
    {
        float HP { get; }

        void RestoreHP();
    }
}
