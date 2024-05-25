using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryDisplayer : MonoBehaviour
{
    [Header("Main Settings")]
    [SerializeField] private SO_InventoryData inventoryData;
    [SerializeField] private GameObject uiInventorySlotPrefab;
    [SerializeField] private Transform slotsParent;

    [Space]

    [Header("Action Buttons")]
    [SerializeField] private bool useActionButtons = false;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button sellOneButton;
    [SerializeField] private Button sellAllButton;

    private UI_InventorySlot selectedSlot = null;

    // Start is called before the first frame update
    void Start()
    {
        inventoryData.onItemAdded += DisplayInventory; // Update inventory with database event     
        
        if (useActionButtons)
        {
            InitButtons();
        }
    }

    [ContextMenu("Testing_DisplayInventory")]
    public void DisplayInventory()
    {
        CleanInventory();
        
        int amount = inventoryData.InventorySlots.Count;
        
        if (amount > 0 )
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject slot = Instantiate(uiInventorySlotPrefab, slotsParent);
                UI_InventorySlot slotScript = slot.GetComponent<UI_InventorySlot>();
                if (slotScript != null )
                {
                    slotScript.InitSlot(inventoryData.InventorySlots[i],this); // inject the slot data from inventory to script
                }
            }          
        }
    }

    public void SetSelecteSlot(UI_InventorySlot newSelectedSlot)
    {
        selectedSlot = newSelectedSlot;
        ItemCategory catg = selectedSlot.SlotData.ItemOnSlot.ItemCategory;

        //Item can be equipped
        if ( catg == ItemCategory.OutfitTop || catg == ItemCategory.OutfitMiddle || catg == ItemCategory.OutfitBotton)
        {
            equipButton.interactable = true;
        }
        else
        {
            equipButton.interactable = false;
        }
    }

    private void CleanInventory()
    {
        int index = slotsParent.childCount;
        if (index > 0)
        {
            for (int i = 0; i < index; i++)
            {
                Destroy(slotsParent.GetChild(i).gameObject);
            }
        }
    }

    private void InitButtons()
    {
        sellAllButton.onClick.AddListener(() => { SellItem(true); });
        sellOneButton.onClick.AddListener(() => { SellItem(false); });
        equipButton.onClick.AddListener(EquipItem);
    }

    private void EquipItem()
    {
        SO_ItemData itemToEquip = selectedSlot.SlotData.ItemOnSlot;
        PlayerOutfitManager.Singleton.Equip(itemToEquip);
    }

    private void SellItem(bool sellAll = false)
    {
        SO_ItemData itemToSell = selectedSlot.SlotData.ItemOnSlot;
        
        if (sellAll)
        {
            int total = selectedSlot.SlotData.AmountOnSlot;
            TransactionManager.Singleton.SellItemToShop(itemToSell, total);
        }
        else
        {
            TransactionManager.Singleton.SellItemToShop(itemToSell, 1);
        }

        DisplayInventory();
    }

    private void OnEnable()
    {
        DisplayInventory();
    }

}
