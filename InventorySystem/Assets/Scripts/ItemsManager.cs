using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Management
{
    public abstract class ItemsManager : MonoBehaviour
    {
        [SerializeField] protected List<ItemData> defaultItems = new List<ItemData>();
        [SerializeField] protected int defaultMaxItems = 0;

        public ItemCollection ItemCollection { get; private set; }

        protected virtual void Start()
        {
            ItemCollection = new ItemCollection(defaultMaxItems);

            defaultItems.ForEach(x => ItemCollection.AddItem(x));
        }

        public bool SendItem(ItemData itemData) => ItemCollection.RemoveItem(itemData);

        public bool ReceiveItem(ItemData itemData) => ItemCollection.AddItem(itemData);
    }
}
