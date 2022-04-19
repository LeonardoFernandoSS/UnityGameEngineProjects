using System;
using UnityEngine;

namespace ItemSystem
{
    [Serializable]
    public class Item
    {
        public Action<int> onChangeAmount;

        [SerializeField] public ItemData ItemData { get; private set; }
        [SerializeField] public int Amount { get; private set; }

        public Item(ItemData itemData, int amount)
        {
            ItemData = itemData;
            Amount = amount;

            onChangeAmount?.Invoke(Amount);
        }

        public Item(ItemData itemData)
        {
            ItemData = itemData;
            Amount = 1;

            onChangeAmount?.Invoke(Amount);
        }

        public void AddAmount()
        {
            if (ItemData == null) return;

            Amount++;

            onChangeAmount?.Invoke(Amount);
        }

        public void SubtractAmount()
        {
            if (Amount == 0) return;

            Amount--;

            onChangeAmount?.Invoke(Amount);
        }
    }
}
