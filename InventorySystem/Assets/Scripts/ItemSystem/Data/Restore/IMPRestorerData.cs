using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Restore
{
    public interface IMPRestorerData : IItemData
    {
        float MP { get; }

        void RestoreMP();
    }
}
