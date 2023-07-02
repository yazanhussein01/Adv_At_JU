using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotManagerScrpt : MonoBehaviour
{
    [SerializeField] Image item_icon;
    [SerializeField] TextMeshProUGUI item_label;
    [SerializeField] TextMeshProUGUI item_number;
    [SerializeField] GameObject obj;


    public void Set(InverntoryItem item)
    {
        item_icon.sprite = item.data.displayIcon;
        item_label.text = item.data.displayName;
        if (item.stackedAmount < 1)
        {
            obj.SetActive(false);
            return;
        }
        item_number.text = item.stackedAmount.ToString();
    }

}
