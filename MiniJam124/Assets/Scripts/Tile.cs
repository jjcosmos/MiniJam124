using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float WidthZ;
    public Action OnThresholdReached;
    private bool _invoked = false;
    public Vector3 End => new Vector3(0f, 0f, transform.position.z + WidthZ);

    private void Update()
    {
        if (!_invoked && Game.Singleton.CurrentPlayer.transform.position.z > transform.position.z + WidthZ)
        {
            OnThresholdReached?.Invoke();
            _invoked = true;
        }
    }
}
