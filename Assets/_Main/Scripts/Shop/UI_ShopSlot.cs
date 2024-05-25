using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShopSlot : UI_InventorySlot
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Button slotButton; //On click should sell to player

    public override void InitSlot(InventorySlotData newData, UI_InventoryDisplayer ownerDisplayer)
    {
        base.InitSlot(newData,ownerDisplayer);
    }

    public override void UpdateSlotData()
    {
        base.UpdateSlotData();
        priceText.text = "$" + SlotData.ItemOnSlot.ItemPrice.ToString();
        itemNameText.text = SlotData.ItemOnSlot.ItemName.ToString();

        slotButton.onClick.RemoveAllListeners();
        slotButton.onClick.AddListener(()=> SellItemOnSlotToPlayer());
    }

    private void SellItemOnSlotToPlayer()
    {
        TransactionManager transactionManager = TransactionManager.Singleton;
        if (transactionManager)
        {
            transactionManager.SellItemToPlayer(SlotData.ItemOnSlot);
            OwnerDisplayer.DisplayInventory();
        }
        else
        {
            Debug.Log("Cant find Transaction Manager Singleton!");
        }
    }
}
