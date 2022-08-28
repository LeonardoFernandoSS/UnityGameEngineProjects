using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
using ItemSystem.Managers;

public class TesterItemSystem : MonoBehaviour
{
    public PlayerStock playerStock;
    public EnvironmentStock environmentStock;
    public PickupItem pickupItem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            environmentStock.Interact();

            TestPlayerStock();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            environmentStock.Interact();

            TestEnvironmentStock();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TestPickupItem();
        }
    }

    void TestPlayerStock()
    {
        if (!playerStock) return;

        playerStock.onChangeItemCollection += DebugPlayerSotck;

        ItemCollection itemCollection = playerStock.ItemCollection;

        if (itemCollection.Items.Count == 0) return;

        Item item = playerStock.ItemCollection.Items[0];

        playerStock.SendItem(item);
    }

    void TestEnvironmentStock()
    {
        if (!environmentStock) return;

        environmentStock.onChangeItemCollection += DebugEnvironmentStock;

        ItemCollection itemCollection = environmentStock.ItemCollection;

        if (itemCollection.Items.Count == 0) return;

        Item item = environmentStock.ItemCollection.Items[0];

        environmentStock.SendItem(item);
    }

    void TestPickupItem()
    {
        if (!pickupItem) return;

        pickupItem.onChangeItem += DebugPickupItem;

        pickupItem.Interact();
    }
    
    void DebugPickupItem(Item item)
    {
        if (item == null) return;

        Debug.Log("Name: " + item.ItemData.Name + " | Amount: " + item.Amount);

        pickupItem.onChangeItem -= DebugPickupItem;
    }

    void DebugEnvironmentStock(ItemCollection itemCollection)
    {
        if (itemCollection == null) return;

        foreach (Item item in itemCollection.Items) Debug.Log("Name: " + item.ItemData.Name + " | Amount: " + item.Amount);

        environmentStock.onChangeItemCollection -= DebugEnvironmentStock;
    }

    void DebugPlayerSotck(ItemCollection itemCollection)
    {
        if (itemCollection == null) return;

        foreach (Item item in itemCollection.Items) Debug.Log("Name: " + item.ItemData.Name + " | Amount: " + item.Amount);

        playerStock.onChangeItemCollection -= DebugPlayerSotck;
    }
}
