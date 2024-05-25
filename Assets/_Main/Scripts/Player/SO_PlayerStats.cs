using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats")]
public class SO_PlayerStats : ScriptableObject
{
    [Header("Base stats")]
    [SerializeField] private string playerName = "Player";
    [SerializeField] private SO_InventoryData playerInventory;
    [SerializeField] private float playerMovementSpeed = 110f;
    [SerializeField] private int playerMoney = 1000;

    [Space]

    [Header("Equipped items")]
    [SerializeField] private SO_ItemData equippedTop; //Hats
    [SerializeField] private SO_ItemData equippedMiddle; // Shirts
    [SerializeField] private SO_ItemData equippedBotton; // Pants

    public string PlayerName { get => playerName; set => playerName = value; }
    public SO_InventoryData PlayerInventory { get => playerInventory; set => playerInventory = value; }
    public float PlayerMovementSpeed { get => playerMovementSpeed; set => playerMovementSpeed = value; }
    public int PlayerMoney { get => playerMoney; set => playerMoney = value; }
    public SO_ItemData EquippedTop { get => equippedTop; set => equippedTop = value; }
    public SO_ItemData EquippedMiddle { get => equippedMiddle; set => equippedMiddle = value; }
    public SO_ItemData EquippedBotton { get => equippedBotton; set => equippedBotton = value; }
}
