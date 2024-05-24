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

    public void InitSlot(InventorySlotData newData)
    {
        slotData = newData;
        UpdateSlotData();
    }

    public void UpdateSlotData()
    {
        if (slotData != null)
        {
            iconImage.sprite = slotData.ItemOnSlot.ItemIcon;
            amountText.text = slotData.AmountOnSlot.ToString();
        }
        else
        {
            iconImage.sprite = null;
            amountText.text = "";
        }
        
    }
}
