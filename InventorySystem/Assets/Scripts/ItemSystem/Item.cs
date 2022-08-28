using System;
using UnityEngine;
using ItemSystem.Data;

namespace ItemSystem
{
    [Serializable]
    public class Item
    {
        public Action<int> onChangeAmount;

        [SerializeField, SerializeReference] private ItemData itemData;
        [SerializeField] private int amount;

        public IItemData ItemData { get => (IItemData)itemData; }

        public int Amount { get => amount; private set { amount = value; /*onChangeAmount?.Invoke(value);*/ } }

        public void SetAmount(int value)
        {
            Amount = Math.Clamp(value, 0, ItemData.MaxAmount);

            onChangeAmount?.Invoke(amount);
        }

        public int AddAmount(int value)
        {
            if (amount == ItemData.MaxAmount || value == 0)
            {
                onChangeAmount?.Invoke(amount);

                return value;
            }             

            amount++;

            value--;

            return AddAmount(value);
        }

        public int SubtractAmount(int value)
        {
            if (Amount == 0 || value == 0)
            {
                onChangeAmount?.Invoke(amount);

                return value;
            }

            amount--;

            value--;

            return SubtractAmount(value);
        }

        public Item Clone()
        {
            return (Item)MemberwiseClone();
        }
    }
}
