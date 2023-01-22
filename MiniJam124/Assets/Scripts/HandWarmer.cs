using UnityEngine;

public class HandWarmer : MonoBehaviour
{
    private void Start()
    {
        // So that they are easy to drag onto the track
        transform.Translate(Vector3.up * Game.Singleton.Settings.WarmerHoverHeight);
        Game.Singleton.ProgressTracker.OnLap += OnLap;
    }

    private void OnDestroy()
    {
        if (!Game.Singleton.ProgressTracker) return;
        Game.Singleton.ProgressTracker.OnLap += OnLap;
        Game.Singleton.ProgressTracker.OnLap -= OnLap;
    }

    private void OnLap(int _)
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Game.Singleton.GameState == GameState.Racing && other.TryGetComponent(out PlayerInventory playerInventory))
        {
            playerInventory.handWarmerCollected();
            gameObject.SetActive(false);
        }
    }
}
