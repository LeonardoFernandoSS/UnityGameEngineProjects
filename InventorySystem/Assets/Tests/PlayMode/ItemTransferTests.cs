using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using ItemSystem;
using ItemSystem.Management;

public class ItemTransferTests
{
    ItemInventory inventory;
    ItemStock stock;

    [UnityTest]
    public IEnumerator AddItemsInventory()
    {
        GameObject go = new GameObject();

        inventory = go.AddComponent<ItemInventory>();

        ItemData itemData = Resources.Load<ItemData>("Items/New Item Data");

        yield return new WaitForSeconds(1);
        
        for (int i = 0; i < 9; i++)
        {
            inventory.ReceiveItem(itemData);
        }

        Debug.Log("\nInventory: " + inventory.ItemCollection.MaxItems);

        inventory.ItemCollection.Items.ForEach(x => Debug.Log(x.ItemData.Name + ": " + x.Amount));

        yield return null;
    }

    [UnityTest]
    public IEnumerator AddItemsStock()
    {
        GameObject go = new GameObject();

        stock = go.AddComponent<ItemStock>();

        ItemData itemData = Resources.Load<ItemData>("Items/New Item Data");

        yield return new WaitForSeconds(1);

        for (int i = 0; i < 10; i++)
        {
            stock.ReceiveItem(itemData);
        }

        Debug.Log("\nEstoque: " + stock.ItemCollection.MaxItems);

        stock.ItemCollection.Items.ForEach(x => Debug.Log(x.ItemData.Name + ": " + x.Amount));

        yield return null;
    }

    [UnityTest]
    public IEnumerator SendItemsInventoryToStock()
    {
        yield return AddItemsInventory();

        yield return AddItemsStock();

        ItemTransfer itemTransfer = new ItemTransfer(inventory, stock);

        ItemData itemData = Resources.Load<ItemData>("Items/New Item Data");

        for (int i = 0; i < 8; i++)
        {
            itemTransfer.SendItem(itemData);
        }        

        Debug.Log("\nInventory: " + inventory.ItemCollection.MaxItems);

        inventory.ItemCollection.Items.ForEach(x => Debug.Log(x.ItemData.Name + ": " + x.Amount));

        Debug.Log("\nEstoque: " + stock.ItemCollection.MaxItems);

        stock.ItemCollection.Items.ForEach(x => Debug.Log(x.ItemData.Name + ": " + x.Amount));

        yield return null;
    }

    [UnityTest]
    public IEnumerator SendItemsStockToInventory()
    {
        yield return AddItemsStock();

        yield return AddItemsInventory();

        ItemTransfer itemTransfer = new ItemTransfer(stock, inventory);

        ItemData itemData = Resources.Load<ItemData>("Items/New Item Data");

        for (int i = 0; i < 8; i++)
        {
            itemTransfer.SendItem(itemData);
        }

        Debug.Log("\nEstoque: " + stock.ItemCollection.MaxItems);

        stock.ItemCollection.Items.ForEach(x => Debug.Log(x.ItemData.Name + ": " + x.Amount));

        Debug.Log("\nInventory: " + inventory.ItemCollection.MaxItems);

        inventory.ItemCollection.Items.ForEach(x => Debug.Log(x.ItemData.Name + ": " + x.Amount));

        yield return null;
    }
}