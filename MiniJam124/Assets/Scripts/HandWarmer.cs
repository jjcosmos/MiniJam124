using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWarmer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.handWarmerCollected();
            gameObject.SetActive(false);
        }
    }
}
