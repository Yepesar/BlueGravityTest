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

    #region Inventory Methods

    public void AddItemToInventory(SO_ItemData item)
    {
        // First try to stack items in existing slots
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].ItemOnSlot == item && !inventorySlots[i].IsFull())
            {
                inventorySlots[i].AddItemToSlot(item);
                return; // Exit once the item is added
            }
        }

        // If no existing slot can accommodate the item, try to find an empty slot
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].ItemOnSlot == null)
            {
                inventorySlots[i].AddItemToSlot(item);
                return; // Exit once the item is added
            }
        }

        // All fail, no available space
        Debug.Log("There is not enough space in the inventory...");
    }

    public bool IsInventoryFull()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].ItemOnSlot == null || !inventorySlots[i].IsFull())
            {
                return false; // Found an available space
            }
        }
        return true; // No available space found
    }

    #endregion

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
            slotID = itemData.name + "s";
        }
        else if (itemOnSlot != itemData) // Items do not match
        {
            return;
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

    public bool IsFull()
    {
        return amountOnSlot >= slotMaxCapacity;
    }
}
