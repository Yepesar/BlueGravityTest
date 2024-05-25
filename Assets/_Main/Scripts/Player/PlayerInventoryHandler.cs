using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryHandler : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private InputActionAsset actions;

    InputAction openInventoryAction;

    // Start is called before the first frame update
    void Start()
    {
        openInventoryAction = actions.FindActionMap("Player").FindAction("OpenInventory");
    }

    // Update is called once per frame
    void Update()
    {
        if (openInventoryAction.triggered)
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeInHierarchy);
        }
    }
}
