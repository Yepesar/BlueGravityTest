using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory {Generic, OutfitTop, OutfitMiddle, OutfitBotton}

[CreateAssetMenu(menuName = "Inventory System/Item Data")]
public class SO_ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private ItemCategory itemCategory;
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private int itemPrice;


    public string ItemName { get => itemName;}
    public Sprite ItemIcon { get => itemIcon;}
    public int ItemPrice { get => itemPrice;}
    public ItemCategory ItemCategory { get => itemCategory;}
}
