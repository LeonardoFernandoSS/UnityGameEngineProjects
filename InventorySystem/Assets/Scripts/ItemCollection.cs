using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    [Serializable]
    public class ItemCollection
    {
        public Action<ItemCollection> onChangedItemCollection;
        public Action<Item> onChangedItem;

        [SerializeField] public List<Item> Items { get; private set; }
        [SerializeField] public int MaxItems { get; private set; }

        public ItemCollection(List<Item> items, int maxItems) 
        {
            Items = items;
            MaxItems = maxItems;

            onChangedItemCollection?.Invoke(this);
        }

        public ItemCollection(int maxItems)
        {
            Items = new List<Item>();
            MaxItems = maxItems;

            onChangedItemCollection?.Invoke(this);
        }

        public bool AddItem(ItemData itemData)
        {
            if (itemData == null) return false;

            Item aux = Items.Find(x => x.ItemData == itemData && x.Amount < x.ItemData.MaxAmount);

            if (aux != null)
            { 
                aux.AddAmount();

                return true;
            }

            if (Items.Count < MaxItems)
            {
                aux = new Item(itemData);

                Items.Add(aux);

                onChangedItem?.Invoke(aux);

                return true;
            }

            return false;
        }

        public bool RemoveItem(ItemData itemData)
        {
            if (itemData == null) return false;

            Item aux = Items.FindLast(x => x.ItemData == itemData);

            if (aux != null) 
            {
                aux.SubtractAmount();

                if (aux.Amount == 0)
                {
                    Items.Remove(aux);

                    onChangedItem?.Invoke(aux);
                }

                return true;
            }

            return false;        
        }
    }
}
