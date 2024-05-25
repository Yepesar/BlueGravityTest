using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIPlayerMoneyDisplayer : MonoBehaviour
{
    [SerializeField] private SO_PlayerStats playerStats;
    [SerializeField] private TextMeshProUGUI playerMoneyText;

    // Update is called once per frame
    void Update()
    {
        if (playerStats != null)
        {
            playerMoneyText.text = playerStats.PlayerMoney.ToString();
        }
    }
}
