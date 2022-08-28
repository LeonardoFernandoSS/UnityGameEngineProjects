using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
using ItemSystem.Managers;

public class PlayerStock : CollectionManager, ICollectionManager, IPlayerStock 
{
    private static IPlayerStock instance ;

    public static IPlayerStock Instance { get => instance; private set => instance = value; }

    private void Awake() => IPlayerStock.Instance = this;

    public ItemCollection ItemCollection { get => itemCollection; }

    public override bool SendItem(Item item)
    {
        IEnvironmentStock environmentStock = IEnvironmentStock.Instance;

        if (environmentStock == null) return false;

        if (!TransferItem(environmentStock.ItemCollection, item)) return false;
        
        return base.SendItem(item);
    }
}

