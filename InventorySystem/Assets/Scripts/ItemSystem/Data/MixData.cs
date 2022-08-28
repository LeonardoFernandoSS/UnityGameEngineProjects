using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data
{
    [CreateAssetMenu(menuName = "Item/MixData")]
    public class MixData : ScriptableObject
    {
        [Header("Mixing Result")]
        [SerializeField] private Item item = new Item();

        [Header("Necessary Items")]
        [SerializeField] private List<Item> items = new List<Item>();
        
        public List<Item> Items { get => items; }

        public Item Item { get => item; }

        public bool CheckItems() => items.Count > 0 || item is not null;
    }
}
