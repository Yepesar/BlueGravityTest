using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDresserHandler : MonoBehaviour
{
    [SerializeField] private SO_PlayerStats playerStats;
    [SerializeField] private Transform topOutfitsParent;
    [SerializeField] private Transform middleOutfitsParent;
    [SerializeField] private Transform botOutfitsParent;

    private void Start()
    {
        DressPlayer();
    }

    public void DressPlayer()
    {
        //Top Outfit
        SO_ItemData top = playerStats.EquippedTop;

        if (top != null )
        {
            for ( int i = 0; i < topOutfitsParent.childCount; i++ )
            {
                if (topOutfitsParent.GetChild(i).GetComponent<PlayerOutfit>().OutfitItem == top)
                {
                    topOutfitsParent.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    topOutfitsParent.GetChild(i).gameObject.SetActive(false);
                }
            }
        }

        //Midlle Outfit
        SO_ItemData middle = playerStats.EquippedMiddle;

        if (middle != null)
        {
            for (int i = 0; i < middleOutfitsParent.childCount; i++)
            {
                if (middleOutfitsParent.GetChild(i).GetComponent<PlayerOutfit>().OutfitItem == middle)
                {
                    middleOutfitsParent.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    middleOutfitsParent.GetChild(i).gameObject.SetActive(false);
                }
            }
        }

        //Bot Outfit
        SO_ItemData bot = playerStats.EquippedBotton;

        if (bot != null)
        {
            for (int i = 0; i < botOutfitsParent.childCount; i++)
            {
                if (botOutfitsParent.GetChild(i).GetComponent<PlayerOutfit>().OutfitItem == bot)
                {
                    botOutfitsParent.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    botOutfitsParent.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
}
