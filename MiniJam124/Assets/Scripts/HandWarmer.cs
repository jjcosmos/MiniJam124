using UnityEngine;

public class HandWarmer : MonoBehaviour
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
            playerInventory.handWarmerCollected();
            gameObject.SetActive(false);
        }
    }
}
