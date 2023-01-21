using UnityEngine;

public class HandWarmer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerInventory playerInventory))
        {
            playerInventory.handWarmerCollected();
            gameObject.SetActive(false);
        }
    }
}
