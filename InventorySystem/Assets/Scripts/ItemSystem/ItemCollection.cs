using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem.Data;

namespace ItemSystem
{
    [Serializable]
    public class ItemCollection
    {
        public Action<ItemCollection> onChangedItemCollection;
        public Action<Item> onChangedItem;

        [SerializeField] private List<Item> items;
        [SerializeField] private int maxItems;

        public List<Item> Items { get => items; }
        public int MaxItems { get => maxItems; }

        public bool CheckSendItem(Item item) => items.Exists(x => x == item);

        public bool CheckReceiveItem(Item item) {

            if (items.Exists(x => x.ItemData == item.ItemData && x.Amount < x.ItemData.MaxAmount)) return true;

            if (items.Count < maxItems) return true;

            return true;
        }

        private bool AllocateAmount(Item item, int amount)
        {
            Item aux = items.FindLast(x => x.ItemData == item.ItemData && x.Amount < x.ItemData.MaxAmount);

            if (aux != null)
            {
                int offset = aux.AddAmount(amount);

                item.SubtractAmount(amount - offset);

                onChangedItem?.Invoke(aux);

                amount = offset;

                if (amount > 0) return AllocateAmount(item, amount);            

                return true;
            }

            if (items.Count < maxItems)
            {
                aux = item.Clone();

                aux.SetAmount(amount);

                item.SubtractAmount(amount);

                items.Add(aux);

                //Debug.Log(item.Amount);

                onChangedItem?.Invoke(aux);

                return true;
            }

            return false;
        }

        public bool ReceiveItem(Item item)
        {
            int amount = item.Amount;

            if (amount > item.ItemData.TransferAmount) amount = item.ItemData.TransferAmount;

            return AllocateAmount(item, amount);
        }

        public void SendItem(Item item)
        {
            if (!items.Exists(x => x == item)) return;

            if (item.Amount == 0)
            {
                items.Remove(item);
            }

            onChangedItem?.Invoke(item);
        }

        public bool AddItem(Item item)
        {
            Item aux = items.FindLast(x => x.ItemData == item.ItemData && x.Amount < x.ItemData.MaxAmount);

            if (aux != null)
            {
                int offset = aux.AddAmount(item.Amount);

                item.SetAmount(item.Amount - offset);
                
                onChangedItem?.Invoke(aux);

                if (item.Amount > 0) return AddItem(item);

                return true;
            }

            if (items.Count < maxItems)
            {
                Item clone = item.Clone();

                item.SetAmount(0);

                items.Add(clone);

                onChangedItem?.Invoke(clone);

                return true;
            }

            return false;
        }

        public bool RemoveItem(Item item)
        {
            if (!items.Exists(x => x == item)) return false;

            item.SubtractAmount(1);

            return true;
        }
    }
}
