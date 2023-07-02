using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_inventory : MonoBehaviour
{
    private Dictionary<InventoyItemData, InverntoryItem> _itemDictionary;
    public List<InverntoryItem> inventory;

    public static player_inventory playerInventory;


    private void Awake()
    {
        playerInventory = this;
        //inventory = new List<InverntoryItem>();
        _itemDictionary = new Dictionary<InventoyItemData, InverntoryItem>();
    }

    public InverntoryItem Get(InventoyItemData refData)
    {
        if(_itemDictionary.TryGetValue(refData, out InverntoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoyItemData refData)
    {
        if (_itemDictionary.TryGetValue(refData, out InverntoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InverntoryItem newItem = new InverntoryItem(refData);
            inventory.Add(newItem);
            _itemDictionary.Add(refData, newItem);
        }
        
    }

    public void Remove(InventoyItemData refData)
    {
        if (_itemDictionary.TryGetValue(refData, out InverntoryItem value))
        {
            value.RemoveFromStack();
            if (value.stackedAmount == 0)
            {
                inventory.Remove(value);
                _itemDictionary.Remove(refData);
            }
        }
    }
}
