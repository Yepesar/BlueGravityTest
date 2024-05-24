using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class UI_InventorySlot : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI amountText;

    private InventorySlotData slotData;
    private UI_InventoryDisplayer ownerDisplayer;

    public Image IconImage { get => iconImage; }
    public TextMeshProUGUI AmountText { get => amountText;}
    public InventorySlotData SlotData { get => slotData; set => slotData = value; }
    public UI_InventoryDisplayer OwnerDisplayer { get => ownerDisplayer; set => ownerDisplayer = value; }

    public virtual void InitSlot(InventorySlotData newData, UI_InventoryDisplayer newOwnerDisplayer)
    {
        SlotData = newData;
        OwnerDisplayer = newOwnerDisplayer;
        UpdateSlotData();
    }

    public virtual void UpdateSlotData()
    {
        if (SlotData != null)
        {
            if (slotData.ItemOnSlot != null)
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
        else
        {
            IconImage.sprite = null;
            AmountText.text = "";
        }
        
    }
}
