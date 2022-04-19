using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using ItemSystem;

public class ItemCollectionTests
{
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

        itemCollection.AddItem(itemData);

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
}
