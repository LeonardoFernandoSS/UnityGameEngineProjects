using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem.Managers;

namespace ItemSystem
{
    public interface ICollectableItem
    {
        Item Item { get; }

        void CollectItem(ICollectionManager collectionManager);
    }
}


