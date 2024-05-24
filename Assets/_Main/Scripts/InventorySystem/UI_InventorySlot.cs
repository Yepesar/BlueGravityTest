using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UI_InventorySlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI amountText;

    private InventorySlotData slotData;

    public Image IconImage { get => iconImage; }
    public TextMeshProUGUI AmountText { get => amountText;}
    public InventorySlotData SlotData { get => slotData; set => slotData = value; }

    public virtual void InitSlot(InventorySlotData newData)
    {
        SlotData = newData;
        UpdateSlotData();
    }

    public virtual void UpdateSlotData()
    {
        if (SlotData != null)
        {
            IconImage.sprite = SlotData.ItemOnSlot.ItemIcon;
            AmountText.text = SlotData.AmountOnSlot.ToString();
        }
        else
        {
            IconImage.sprite = null;
            AmountText.text = "";
        }
        
    }
}
