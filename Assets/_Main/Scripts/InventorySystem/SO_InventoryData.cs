using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Data")]
public class SO_InventoryData : ScriptableObject
{
    [Header("Main settings")]
    [SerializeField] private string inventoryID = "Inventory";
    [SerializeField] private int inventoryMaxSlots = 10;
    [SerializeField] private int inventoryMaxStack = 100;

    [Space]

    [Header("Slots")]
    [SerializeField] private List<InventorySlotData> inventorySlots;

    [Space]
    [Header("Testing")]
    [SerializeField] private SO_ItemData testingItem;

    public string InventoryID { get => inventoryID;}
    public int InventoryMaxSlots { get => inventoryMaxSlots;}
    public int InventoryMaxStack { get => inventoryMaxStack;}
    public List<InventorySlotData> InventorySlots { get => inventorySlots;}

    [ContextMenu("Init Inventory")]
    public void InitInventory()
    {
        inventorySlots = new List<InventorySlotData>();
        for (int i = 0; i < inventoryMaxSlots; i++)
        {
            inventorySlots.Add(new InventorySlotData(inventoryMaxStack));
        }
    }

    #region Testing

    [ContextMenu("Testing_PopulateInventory")]
    private void PopulateInventoryWithTestingItem()
    {
        for (int i = 0; i < inventoryMaxSlots;i++)
        {
            inventorySlots[i].AddItemToSlot(testingItem);
        }
    }

    #endregion
}

[Serializable]
public class InventorySlotData
{
    [SerializeField, ReadOnly] private string slotID = "EmptySlot";
    [SerializeField] private SO_ItemData itemOnSlot;
    [SerializeField] private int amountOnSlot;
    [SerializeField, ReadOnly] private int slotMaxCapacity = 100;

    public SO_ItemData ItemOnSlot { get => itemOnSlot; set => itemOnSlot = value; }
    public int AmountOnSlot { get => amountOnSlot; set => amountOnSlot = value; }

    //Constructor
    public InventorySlotData(int slotMaxStackCapacity = 100) 
    {
        InitSlot(slotMaxStackCapacity); 
    }

    public void InitSlot(int maxCapacity = 100)
    {
        slotMaxCapacity = maxCapacity;
    }

    public void AddItemToSlot(SO_ItemData itemData)
    {
        if (itemOnSlot == null)
        {
            itemOnSlot = itemData;
        }
        else
        {
            if (itemOnSlot != itemData) // Error case, items dont match
            {
                return;
            }
        }


        if (amountOnSlot == 0)
        {
            string slotNewID = itemData.name + "s";
            slotID = slotNewID;
        }

        if (amountOnSlot < slotMaxCapacity)
        {
            amountOnSlot++;
        }
    }

    public void RemoveItemFromSlot()
    {
        if (amountOnSlot > 0)
        {
            amountOnSlot--;

            if (amountOnSlot == 0)
            {
                slotID = "EmptySlot";
                itemOnSlot = null;
            }
        }
    }
}
