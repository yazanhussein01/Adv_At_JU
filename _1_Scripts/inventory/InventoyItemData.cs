using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Inventotry Item Data")]
public class InventoyItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public int price;
    public Sprite displayIcon;
}
