using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ItemSystem;
using ItemSystem.Data;

public class ItemTests
{
    [SerializeField] public Item item = new Item();

    [UnityTest]
    public IEnumerator AddOneAmount()
    {
        Debug.Log(item.ItemData.Name + ": " + item.Amount);

        item.AddAmount(5);

        Debug.Log(item.ItemData.Name + ": " + item.Amount);

        yield return null;
    }
    /*
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
    */
}
