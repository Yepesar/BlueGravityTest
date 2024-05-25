using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionManager : MonoBehaviour
{
    [SerializeField] private SO_PlayerStats playerStats;

    public static TransactionManager Singleton;

    private void Awake()
    {
        if (Singleton == null) 
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }
 
    public void SellItemToShop(SO_ItemData itemToSell, int quantity)
    {
        //Do transaction
        int gains = itemToSell.ItemPrice * quantity;
        playerStats.PlayerInventory.RemoveItemFromInventory(itemToSell, quantity);
        playerStats.PlayerMoney += gains;
    }

    public void SellItemToPlayer(SO_ItemData itemToSell)
    {
        //Validate player has money and space on inventory
        if(!PlayerHasEnoughtMoney(itemToSell.ItemPrice) || playerStats.PlayerInventory.IsInventoryFull())
        {
            Debug.Log("Player dont have money or space!");
            return;
        }
       
        //Do transaction
        playerStats.PlayerMoney -= itemToSell.ItemPrice;
        playerStats.PlayerInventory.AddItemToInventory(itemToSell);
        
    }

    private bool PlayerHasEnoughtMoney(int amount)
    {
        bool hasMoney = false;
        int diff = playerStats.PlayerMoney - amount;

        if (diff > 0)
        {
            hasMoney = true;
        }

        return hasMoney;
    }
}
