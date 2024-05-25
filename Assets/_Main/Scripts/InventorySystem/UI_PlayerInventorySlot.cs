using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerInventorySlot : UI_InventorySlot
{
    [SerializeField] private Button slotButton;
    [SerializeField] private GameObject slotMenu;

    // Start is called before the first frame update
    void Start()
    {
        slotButton.onClick.AddListener(NotifyOwnerOfSelection);
    }

    private void NotifyOwnerOfSelection()
    {
        if (OwnerDisplayer)
        {
            OwnerDisplayer.SetSelecteSlot(this);
        }
    }
}
