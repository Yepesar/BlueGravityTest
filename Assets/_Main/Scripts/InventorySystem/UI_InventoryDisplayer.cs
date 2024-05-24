using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryDisplayer : MonoBehaviour
{
    [SerializeField] private SO_InventoryData inventoryData;
    [SerializeField] private GameObject uiInventorySlotPrefab;
    [SerializeField] private Transform slotsParent;


    [ContextMenu("Testing_DisplayInventory")]
    private void DisplayInventory()
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
                    slotScript.InitSlot(inventoryData.InventorySlots[i]); // inject the slot data from inventory to script
                }
            }          
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
