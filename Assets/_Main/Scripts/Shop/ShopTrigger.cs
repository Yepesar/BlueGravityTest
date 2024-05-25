using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject indicator;

    public void Interact()
    {
        shopUI.gameObject.SetActive(true);
        playerUI.gameObject.SetActive(true);
        indicator.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        indicator.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        indicator.SetActive(false);
    }
}
