using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out PlayerInventory playerInventory))
        {
            playerInventory.Collisionhit();
            //gameObject.SetActive(false);
        }
    }
}
