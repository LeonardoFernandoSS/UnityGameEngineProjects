using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Managers
{
    public abstract class CollectionManager : MonoBehaviour
    {
        public Action<ItemCollection> onChangeItemCollection;

        [SerializeField] protected ItemCollection itemCollection = new ItemCollection();

        public virtual bool SendItem(Item item)
        {
            onChangeItemCollection?.Invoke(itemCollection);

            return true;
        }

        protected bool TransferItem(ItemCollection itemCollection, Item item) 
        {
            if (!this.itemCollection.CheckSendItem(item) || !itemCollection.CheckReceiveItem(item)) return false;
            
            itemCollection.ReceiveItem(item);

            this.itemCollection.SendItem(item);

            return true;
        }
    }
}
