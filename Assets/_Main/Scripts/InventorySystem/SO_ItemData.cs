using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Item Data")]
public class SO_ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private int itemPrice;

    public string ItemName { get => itemName;}
    public Sprite ItemIcon { get => itemIcon;}
    public int ItemPrice { get => itemPrice;}
}
