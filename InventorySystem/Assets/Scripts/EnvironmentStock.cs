using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
using ItemSystem.Managers;

public class EnvironmentStock : CollectionManager, ICollectionManager, IEnvironmentStock, IInteractableObject
{
    private static IEnvironmentStock instance;

    public static IEnvironmentStock Instance { get => instance; set => instance = value; }

    public ItemCollection ItemCollection { get => itemCollection; }

    public override bool SendItem(Item item)
    {
        IPlayerStock playerStock = IPlayerStock.Instance;

        if (!TransferItem(playerStock.ItemCollection, item)) return false;

        return base.SendItem(item);
    }

    public void Interact()
    {
        IEnvironmentStock.Instance = this;
    }
}
