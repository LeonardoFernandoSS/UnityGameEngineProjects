using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ItemSystem;

public class ItemTests
{
    [UnityTest]
    public IEnumerator AddOneAmount()
    {
        ItemData itemData = Resources.Load<ItemData>("Items/New Item Data");

        Item item = new Item(itemData, 5);

        Debug.Log(item.ItemData.Name + ": " + item.Amount);

        item.AddAmount();

        Debug.Log(item.ItemData.Name + ": " + item.Amount);

        yield return null;
    }

    [UnityTest]
    public IEnumerator SubtractOneAmount()
    {
        ItemData itemData = Resources.Load<ItemData>("Items/New Item Data");

        Item item = new Item(itemData, 0);

        Debug.Log(item.ItemData.Name + ": " + item.Amount);

        item.SubtractAmount();

        Debug.Log(item.ItemData.Name + ": " + item.Amount);

        yield return null;
    }
}
