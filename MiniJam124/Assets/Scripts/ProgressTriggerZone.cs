using UnityEngine;

public class ProgressTriggerZone : MonoBehaviour
{
    public ProgressTracker Owner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player _))
        {
            Owner.TriggerZoneEntered(this);
        }
    }
}
