using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using ItemSystem;

public class ItemCollectionTests //: ICollectableItem//, IInteractableObject
{
    /*
    private int amount = 10;

    public ItemData ItemData { get => Resources.Load<ItemData>("Items/New Item Data"); }

    public int Amount { get => amount; }

    public void CollectItem(ItemCollection itemCollection)
    {
        itemCollection.AddItem(ItemData);
    }

    [UnityTest]
    public IEnumerator AddOneItemData()
    {
        ItemData itemData = Resources.Load<ItemData>("Items/New Item Data");

        ItemCollection itemCollection = new ItemCollection(
            new List<Item>() 
            { 
                new Item(itemData, 5), 
                new Item(itemData, 4) 
            }, 
            1);

        Debug.Log("---");

        itemCollection.Items.ForEach(x => Debug.Log(x.ItemData.Name + ": " + x.Amount));

        CollectItem(itemCollection);

        Debug.Log("---");

        itemCollection.Items.ForEach(x => Debug.Log(x.ItemData.Name + ": " + x.Amount));

        yield return null;
    }

    [UnityTest]
    public IEnumerator RemoveOneItemData()
    {
        ItemData itemData = Resources.Load<ItemData>("Items/New Item Data");

        ItemCollection itemCollection = new ItemCollection(
            new List<Item>()
            {
                new Item(itemData, 5),
                new Item(itemData, 4)
            },
            1);

        Debug.Log("---");

        itemCollection.Items.ForEach(x => Debug.Log(x.ItemData.Name + ": " + x.Amount));

        itemCollection.RemoveItem(itemData);
        itemCollection.RemoveItem(itemData);
        itemCollection.RemoveItem(itemData);
        itemCollection.RemoveItem(itemData);
        itemCollection.RemoveItem(itemData);
        itemCollection.RemoveItem(itemData);

        Debug.Log("---");

        itemCollection.Items.ForEach(x => Debug.Log(x.ItemData.Name + ": " + x.Amount));

        yield return null;
    }

    */
}
