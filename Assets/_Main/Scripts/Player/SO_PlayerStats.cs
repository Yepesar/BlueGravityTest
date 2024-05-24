using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats")]
public class SO_PlayerStats : ScriptableObject
{
    [SerializeField] private string playerName = "Player";
    [SerializeField] private SO_InventoryData playerInventory;
    [SerializeField] private float playerMovementSpeed = 110f;
    [SerializeField] private int playerMoney = 1000;

    public string PlayerName { get => playerName; set => playerName = value; }
    public SO_InventoryData PlayerInventory { get => playerInventory; set => playerInventory = value; }
    public float PlayerMovementSpeed { get => playerMovementSpeed; set => playerMovementSpeed = value; }
    public int PlayerMoney { get => playerMoney; set => playerMoney = value; }
}
