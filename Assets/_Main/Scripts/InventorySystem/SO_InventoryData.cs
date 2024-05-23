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
}

[Serializable]
public class InventorySlotData
{
    [SerializeField, ReadOnly] private string slotID = "EmptySlot";
    [SerializeField] private List<SO_ItemData> itemsOnSlot = new List<SO_ItemData>();
    [SerializeField, ReadOnly] private int slotMaxCapacity = 100;

    private int actualItems = 0;

    //Constructor
    public InventorySlotData(int slotMaxStackCapacity = 100) 
    {
        InitSlot(slotMaxStackCapacity); 
    }


    public List<SO_ItemData> ItemsOnSlot { get => itemsOnSlot; set => itemsOnSlot = value; }

    public void InitSlot(int maxCapacity = 100)
    {
        slotMaxCapacity = maxCapacity;
    }

    public void AddItemToSlot(SO_ItemData itemData)
    {
        if (actualItems == 0)
        {
            string slotNewID = itemData.name + "s";
            slotID = slotNewID;
        }


        if (actualItems < slotMaxCapacity)
        {
            ItemsOnSlot.Add(itemData);
            actualItems++;
        }
    }

    public void RemoveItemFromSlot()
    {
        if (actualItems > 0)
        {
            int index = ItemsOnSlot.Count - 1;
            ItemsOnSlot.RemoveAt(index);
            actualItems--;

            if (actualItems == 0)
            {
                slotID = "EmptySlot";
            }
        }
    }
}
