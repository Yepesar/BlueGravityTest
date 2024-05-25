using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerOutfitManager : MonoBehaviour
{
    [SerializeField] private SO_PlayerStats playerStats;

    public static PlayerOutfitManager Singleton;

    private PlayerDresserHandler dressHandler;

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

    // Start is called before the first frame update
    void Start()
    {
        dressHandler = GameObject.FindFirstObjectByType<PlayerDresserHandler>();
    }

    private void UpdatePlayerGraphics()
    {
        if (dressHandler)
        {
            dressHandler.DressPlayer();
        }
    }

    public void Equip(SO_ItemData item)
    {
        if (item.ItemCategory == ItemCategory.OutfitTop)
        {
            playerStats.EquippedTop = item;
        }
        else if (item.ItemCategory == ItemCategory.OutfitMiddle)
        {
            playerStats.EquippedMiddle = item;
        }
        else
        {
            playerStats.EquippedBotton = item;
        }

        UpdatePlayerGraphics();
    }
}
