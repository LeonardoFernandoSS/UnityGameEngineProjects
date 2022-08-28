using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Managers

{
    public interface ICollectionManager
    {
        ItemCollection ItemCollection { get; }

        bool SendItem(Item item);
    }
}
