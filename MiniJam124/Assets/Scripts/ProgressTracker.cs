using System;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    [SerializeField] private List<ProgressTriggerZone> _triggerZones;
    private int _currentIndex = 0;
    public Action<int> OnLap;

    private void Start()
    {
        foreach (var progressTriggerZone in _triggerZones)
        {
            progressTriggerZone.Owner = this;
        }
        OnLap?.Invoke(0);
    }

    public Vector3 LookAtTriggerZonePosition()
    {
        return _triggerZones[(_currentIndex + 1)%_triggerZones.Count].transform.position;
    }

    public void TriggerZoneEntered(ProgressTriggerZone zone)
    {
        var index = _triggerZones.IndexOf(zone);
        // If it isn't the next zone, ignore.
        if (index != (_currentIndex + 1) % _triggerZones.Count) return;
        
        _currentIndex++;
        
        if (index == 0)
        {
            var laps = _currentIndex / _triggerZones.Count;
            OnLap?.Invoke(laps);
        }
    }
}