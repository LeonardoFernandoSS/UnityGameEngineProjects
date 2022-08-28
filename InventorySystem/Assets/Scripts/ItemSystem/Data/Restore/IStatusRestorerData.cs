using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Restore
{
    public interface IStatusRestorerData : IItemData
    {
        List<string> Status { get; }

        void RestoreStatus();
    }
}
