using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InverntoryItem
{
    public InventoyItemData data;
    public int stackedAmount;

    public InverntoryItem(InventoyItemData refData)
    {
        data = refData;   
        AddToStack();
    }

    public void AddToStack()
    {
        stackedAmount++;
    }

    public void RemoveFromStack()
    {
        stackedAmount--;
    }
}
