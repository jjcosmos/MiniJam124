using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Start()
    {
        // So that they are easy to drag onto the track
        transform.Translate(Vector3.up * Game.Singleton.Settings.WarmerHoverHeight);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerInventory playerInventory))
        {
            playerInventory.Collisionhit();
            gameObject.SetActive(false);
        }
    }
}
