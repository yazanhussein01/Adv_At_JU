using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManagerScrpt : MonoBehaviour
{
    [SerializeField] GameObject slotPrefab;


    public void OnUpdateInventory()
    {
        foreach (Transform t in transform)
            Destroy(t.gameObject);
        MakeInventory();
    }

    public void MakeInventory()
    {
        foreach(InverntoryItem item in player_inventory.playerInventory.inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InverntoryItem item)
    {
        GameObject obj = Instantiate(slotPrefab, transform, false);

        SlotManagerScrpt slot = obj.GetComponent<SlotManagerScrpt>();
        slot.Set(item);
    }

}
