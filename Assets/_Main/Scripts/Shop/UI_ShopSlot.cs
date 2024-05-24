using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ShopSlot : UI_InventorySlot
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI itemNameText;

    private Button slotButton; //On click should sell to player

    private void Start()
    {
        slotButton = GetComponent<Button>();
    }

    public override void InitSlot(InventorySlotData newData)
    {
        base.InitSlot(newData);
    }

    public override void UpdateSlotData()
    {
        base.UpdateSlotData();
        priceText.text = "$" + SlotData.ItemOnSlot.ItemPrice.ToString();
        itemNameText.text = SlotData.ItemOnSlot.ItemName.ToString();
    }
}
