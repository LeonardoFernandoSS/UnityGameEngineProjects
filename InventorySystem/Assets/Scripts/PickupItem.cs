using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
using ItemSystem.Managers;

public class PickupItem : MonoBehaviour, ICollectableItem, IInteractableObject
{
    public Action<Item> onChangeItem;

    [SerializeField] private Item item;

    public Item Item { get => item; }

    public void CollectItem(ICollectionManager collectionManager)
    {
        item.onChangeAmount += CheckItem;

        collectionManager.ItemCollection.AddItem(item);
    }

    private void CheckItem(int amount)
    {
        if (amount == 0)
        {
            item.onChangeAmount -= CheckItem;

            onChangeItem?.Invoke(item);

            Destroy(gameObject);
        }
    }

    public void Interact()
    {
        CollectItem(IPlayerStock.Instance);
    }
}
